﻿namespace eZet.Eve.EveLib.Util {
    /// <summary>
    ///     Provides serialization methods for Eve API xml and objects.
    /// </summary>
    public interface ISerializer {
        /// <summary>
        ///     Deserializes Eve API xml.
        /// </summary>
        /// <typeparam name="T">Parameter type for EveApiResponse.</typeparam>
        /// <param name="data">String of XML to deserialize.</param>
        /// <returns></returns>
        T Deserialize<T>(string data);
    }
}