namespace PrimeGearApp.Common
{
    public static class SeeingConstants
    {
        public static class ProductTypeSeeding
        {
            public const int CPUId = 1;
            public const int GPUId = 2;
            public const int CPUAIOCoolerId = 3;
            public const int HeadsetId = 4;
            public const int MonitorId = 5;
            public const int MousePadId = 6;
            public const int SSDId = 7;
            public const int MonitorStandId = 8;
            public const int MouseId = 9;
            public const int PcCaseId = 10;
            public const int HDDId = 11;
            public const int RAMId = 12;
            public const int KeyboardId = 13;
            public const int PowerSupplyId = 14;
            public const int CPUFanCoolerId = 15;
            public const int MotherBoardId = 16;
            public const int CoolingFanId = 17;
        }
        public static class ProductTypeProperties
        {
            public static class GPUProperties
            {
                public static readonly IReadOnlyList<string> GpuProperties = new List<string>
                {
                    "CoreClockSpeed",
                    "BoostClockSpeed",
                    "CudaCores",
                    "MemorySize",
                    "MemoryType",
                    "TDP",
                    "RecommendedPSUWattage",
                    "FanCount",
                    "HasRGB",
                    "CoolerType",
                    "Length",
                    "SlotWidth",
                    "Weight",
                    "HDMIOutputPortsCount",
                    "DisplayPortOutputPortsCount",
                    "DVIOutputPortsCount",
                    "VGAOutputPortsCount",
                }.AsReadOnly();
            }
        }
    }

}