﻿using DoAnMonHoc.ViewModel;

namespace DoAnMonHoc.Vnpay
{
	public class VnPayService : IVnPayService
	{
		private readonly IConfiguration config; // lấy dữ liệu từ appsetting.json

		public VnPayService(IConfiguration config)
		{
			this.config = config;
		}
		//Build URL for VNPAY
		public string InitialPayment(HttpContext context, OrderInfo model)
		{
			var tick = DateTime.Now.Ticks.ToString();
			var vnpay = new VnPayLibrary();
			vnpay.AddRequestData("vnp_Version", config["VnPay:Version"]);
			vnpay.AddRequestData("vnp_Command", config["VnPay:Command"]);
			vnpay.AddRequestData("vnp_TmnCode", config["VnPay:TmnCode"]);
			vnpay.AddRequestData("vnp_Amount", (model.Amount * 100).ToString()); //Số tiền thanh toán. Số tiền không mang các ký tự phân tách thập phân, phần nghìn, ký tự tiền tệ. Để gửi số tiền thanh toán là 100,000 VND (một trăm nghìn VNĐ) thì merchant cần nhân thêm 100 lần (khử phần thập phân), sau đó gửi sang VNPAY là: 10000000
			vnpay.AddRequestData("vnp_CreateDate", model.CreatedDate.ToString("yyyyMMddHHmmss"));
			vnpay.AddRequestData("vnp_CurrCode", config["VnPay:CurrCode"]);
			vnpay.AddRequestData("vnp_IpAddr", Utils.GetIpAddress(context));
			vnpay.AddRequestData("vnp_Locale", config["VnPay:Locale"]);
			vnpay.AddRequestData("vnp_OrderInfo", "Thanh toan don hang:" + model.OrderId);
			vnpay.AddRequestData("vnp_OrderType", "other"); //default value: other

			vnpay.AddRequestData("vnp_ReturnUrl", config["VnPay:PaymentBackReturnUrl"]);
			vnpay.AddRequestData("vnp_TxnRef", tick); // Mã tham chiếu của giao dịch tại hệ thống của merchant. Mã này là duy nhất dùng để phân biệt các đơn hàng gửi sang VNPAY. Không được trùng lặp trong ngày

			var paymentUrl = vnpay.CreateRequestUrl(config["VnPay:BaseUrl"], config["VnPay:HashSecret"]);
			return paymentUrl;
		}
		//vnp-ip
		public VnpayResponse ExecutePayment(IQueryCollection collections)
		{
			VnPayLibrary vnpay = new VnPayLibrary();
			foreach (var (key, value) in collections)
			{
				if (!string.IsNullOrEmpty(key) && key.StartsWith("vnp_"))
				{
					vnpay.AddResponseData(key, value.ToString());
				}
			}
			var vnp_orderId = Convert.ToInt64(vnpay.GetResponseData("vnp_TxnRef"));
			var vnp_TransactionId = Convert.ToInt64(vnpay.GetResponseData("vnp_TransactionNo"));
			var vnp_ResponseCode = vnpay.GetResponseData("vnp_ResponseCode");
			var vnp_TransactionStatus = vnpay.GetResponseData("vnp_TransactionStatus");
			var vnp_SecureHash = collections.FirstOrDefault(p => p.Key == "vnp_SecureHash").Value;
			var vnp_OrderInfo = vnpay.GetResponseData("vnp_OrderInfo");
			bool checkSignature = vnpay.ValidateSignature(vnp_SecureHash, config["VnPay:HashSecret"]);
			if (!checkSignature)
			{
				return new VnpayResponse
				{
					Success = false
				};
			}
			return new VnpayResponse
			{
				Success = true,
				PaymentMethod = "VnPay",
				OrderDescription = vnp_OrderInfo,
				OrderId = vnp_orderId.ToString(),
				TransactionId = vnp_TransactionId.ToString(),
				Token = vnp_SecureHash,
				VnPayResponseCode = vnp_ResponseCode
			};
		}
	}
}
