﻿using System.Net.Http;
using System.Threading.Tasks;

using CryptoCompare.Core;
using CryptoCompare.Helpers;
using CryptoCompare.Responses;

using JetBrains.Annotations;

namespace CryptoCompare.Clients
{
    /// <summary>
    /// The coins client. Gets general info for all the coins available on the website.
    /// </summary>
    /// <seealso cref="T:CryptoCompare.Clients.ICoinsClient"/>
    public class CoinsClient : BaseApiClient, ICoinsClient
    {
        /// <summary>
        /// Initializes a new instance of the CryptoCompare.Clients.CoinsClient class.
        /// </summary>
        /// <param name="httpClient">The HTTP client. This cannot be null.</param>
        public CoinsClient([NotNull] HttpClient httpClient)
            : base(httpClient)
        {
        }

        /// <summary>
        /// Returns all the coins that CryptoCompare has added to the website.
        /// </summary>
        /// <seealso cref="M:CryptoCompare.Clients.ICoinsClient.AllCoinsAsync()"/>
        public async Task<CoinList> ListAsync()
        {
            return await this.SendRequestAsync<CoinList>(HttpMethod.Get, ApiUrls.AllCoins());
        }

        /// <summary>
        /// Gets data for a currency pair. It returns general block explorer information,
        /// aggregated data and individual data for each exchange available.
        /// </summary>
        /// <param name="fromSymbol">The symbol of the currency you want to get that for.</param>
        /// <param name="toSymbol">The symbol of the currency that data will be in.</param>
        /// <seealso cref="M:CryptoCompare.Clients.ICoinsClient.SnapshotAsync(string,string)"/>
        public async Task<CoinSnapshot> SnapshotAsync([NotNull] string fromSymbol, [NotNull] string toSymbol)
        {
            Check.NotNull(toSymbol, nameof(toSymbol));
            Check.NotNull(fromSymbol, nameof(fromSymbol));
            return await this.SendRequestAsync<CoinSnapshot>(HttpMethod.Get, ApiUrls.CoinSnapshot(fromSymbol, toSymbol));
        }
    }
}
