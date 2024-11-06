namespace Evcomp.API.Models.Dto
{
    public class ComputerCreateDTO
    {
        public IFormFile? File { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0;
        public string Processor { get; set; } = string.Empty;
        public string GraphicsCard { get; set; } = string.Empty;
        public string Motherboard { get; set; } = string.Empty;
        public string PowerSupply { get; set; } = string.Empty;
        public string RAM { get; set; } = string.Empty;
        public string Storage { get; set; } = string.Empty;
        public string ProcessorCooler { get; set; } = string.Empty;
        public string Case { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public bool HasWiFi { get; set; }
        public bool HasLightingControl { get; set; }
    }
}
