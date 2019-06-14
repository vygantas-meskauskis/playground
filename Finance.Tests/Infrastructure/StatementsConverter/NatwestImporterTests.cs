using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Finance.StatementsConverter.FileImportStrategies;
using Xunit;

namespace Finance.Tests.Infrastructure.StatementsConverter
{
    public class NatwestImporterTests
    {
        private const string ValidNatwestData = 
            "13/06/2019,POS,\"'9052 12JUN19 C , TK MAXX , LONDON GB\",-14.99,5433.84,\"'GENERAL\",\"'603006-26849925\"," + 
            "13/06/2019,POS,\"'9052 12JUN19 , TK MAXX , LONDON GB\",-49.99,5448.83,\"'GENERAL\",\"'603006-26849925\",";

        [Fact]
        public void ImportFinanceRecords_ShouldImportFinanceRecords_WhenDataIsValid()
        {
            var importer = new NatwestRecordsImportStrategy();

            //act
            var result = importer.ImportFinanceRecords(GenerateStreamFromString(ValidNatwestData));

            Assert.Equal(2, result.Count);
        }

        public static MemoryStream GenerateStreamFromString(string value)
        {
            return new MemoryStream(Encoding.UTF8.GetBytes(value ?? ""));
        }
    }
}
