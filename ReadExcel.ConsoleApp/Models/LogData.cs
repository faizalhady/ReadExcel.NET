public class LogData
{
    public int Id { get; set; }  // Primary key

    public required string Model { get; set; }
    public required string SerialNo { get; set; }
    public required string Process { get; set; }
    public required DateTime Timestamp { get; set; }
    public required string SoftwareVersion { get; set; }
    public required string Status { get; set; }
    public required string PCName { get; set; }
    public required string IPAddress { get; set; }
    public DateTime DataProcessedAt { get; set; }
}
