﻿namespace SIRS.RMT.Config.Sections
{
    public class ApplicationSection
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public override string ToString()
        {
            return $"{this.Name}, {this.Code}";
        }
    }
}