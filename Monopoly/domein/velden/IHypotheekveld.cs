using System;
using Monopoly.domein.akties;
namespace Monopoly.domein.velden
{
    public interface IHypotheekveld : IVeld
    {
        int Koopprijs   { get; }
        Speler Eigenaar { get; }
        Hypotheek Hypotheek { get; }
        int BepaalHuurprijs();


        /// <summary>
        /// Verkoop een straat aan een speler
        /// </summary>
        /// <param name="koper"></param>
        /// <returns></returns>
        bool Verkoop(Speler koper);

    }
}
