﻿using System.Globalization;

namespace SwedbankPay.Sdk
{
    /// <summary>
    /// Holds shared information about a address.
    /// </summary>
    public interface IAddress
    {
        /// <summary>
        /// The payers city of residence.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// The C/O address of the payer, if applicable.
        /// </summary>
        public string CoAddress { get; set; }

        /// <summary>
        /// The country code of the payers country of residence.
        /// </summary>
        public RegionInfo CountryCode { get; set; }

        /// <summary>
        /// Payers street address in their city of residence.
        /// </summary>
        public string StreetAddress { get; set; }

        /// <summary>
        /// Payers zip code of their country of residence.
        /// </summary>
        public string ZipCode { get; set; }
    }
}