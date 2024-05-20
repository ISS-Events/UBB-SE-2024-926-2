﻿using System.Drawing;
using CodeBuddies.Models.Entity;
using CodeBuddies.Utils;

namespace CodeBuddies.Models.Entities
{
    public class Badge : IBadge
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Image? Image { get; set; }
        public Badge()
        {
            ID = IDGenerator.Default();
            Name = "New Badge";
            Description = "None provided";
            Image = null;
        }
        public override string ToString()
        {
            return $"Badge(id: {ID}, badgeName: {Name}, image: {Image})"
                + $"badgeDescription: {Description}";
        }
    }
}
