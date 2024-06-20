namespace MySolidWebApi.Models
{
    public class SurfScore : IScore
    {
        public int WaveId { get; set; }
        public int SurferId { get; set; }
        public double[] Scores { get; set; }
        public double FinalScore { get; set; }
    }
}
