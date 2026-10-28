namespace Temp_BE.Domain.Enums
{
    public enum ReportType
    {
        SanPham = 0,
        BalanceSheet = 1,
        IncomeStatement = 2,
        CashFlow = 3,
        GeneralJournal = 4,
        GeneralLedger = 5,  
        VatReport = 6,
        ReceiptVoucher = 7,
        PaymentVoucher = 8,
        Invoice = 9
    }

    public enum ExportFormat
    {
        Pdf = 1,
        Excel = 2,
        Csv = 3
    }
}
