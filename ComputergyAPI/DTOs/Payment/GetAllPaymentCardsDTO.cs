﻿namespace ComputergyAPI.DTOs.Payment
{
    public class GetAllPaymentCardsDTO
    {
        public string? CardNumber { get; set; }
        public string? CardHolder { get; set; }
        public string? ExpirationDate { get; set; }

        public string? CVC { get; set; }
        public int? UserId { get; set; }
    }
}
