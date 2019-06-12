using Finance.Application.Reports.Models;
using Finance.StatementsConverter.FileImportStrategies;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace Finance.Tests.Infrastructure.StatementsConverter
{
    public class RevolutImporterTests
    {
        private const string ValidRevolutData =
            "Completed Date ; Description ; Paid Out (GBP) ; Paid In (GBP) ; Exchange Out; Exchange In; Balance (GBP); Category; Notes\n" +
            "6 Jun 2019 ; Airbnb ; 122.62 ;  ;  ;  ; 10.61; travel;\n" +
            "1 Jun 2019 ; Top-Up by *9052  ;  ; 130.00 ;  ;  ; 133.23; general;notes\n";

        private readonly List<FinanceRecordItem> ValidImportedData = new List<FinanceRecordItem>
        {
            new FinanceRecordItem(new DateTime(2019, 06, 06), "Airbnb", "travel", -122.62, 10.61, null),
            new FinanceRecordItem(new DateTime(2019, 06, 01), "Top-Up by *9052", "travel", 130.00, 133.23, "notes")
        };

        [Fact]
        public void ImportFinanceRecords_ShouldImportFinanceRecords_WhenDataIsValid()
        {
            var importer = new RevolutRecordsImportStrategy();

            //act
            var result = importer.ImportFinanceRecords(GenerateStreamFromString(ValidRevolutData));

            Assert.Equal(ValidImportedData, result);
        }

        public static MemoryStream GenerateStreamFromString(string value)
        {
            return new MemoryStream(Encoding.UTF8.GetBytes(value ?? ""));
        }
    }
}
