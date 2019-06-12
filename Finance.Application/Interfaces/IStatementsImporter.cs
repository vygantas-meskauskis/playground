using System.Collections.Generic;
using System.IO;
using Finance.Application.Reports.Models;

namespace Finance.Application.Interfaces
{
    public interface IBankRecordsImportStrategy
    {
        List<FinanceRecordItem> ImportFinanceRecords(Stream file);
    }
}
