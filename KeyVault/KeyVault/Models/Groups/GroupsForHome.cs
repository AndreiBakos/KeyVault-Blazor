using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KeyVault.Entities;
using KeyVault.Models.User;

namespace KeyVault.Models.Groups
{
    public class GroupsForHome
    {
        [MaxLength(250)]
        public string GroupId { get; set; }
        
        [MaxLength(250)]
        public string Title { get; set; }
        
        [MaxLength(250)]
        public string OwnerId { get; set; }
        
        public IEnumerable<UserForHome> Members { get; set; }

        public GroupsForHome() { }

        public GroupsForHome(Group group, IEnumerable<UserForHome> members)
        {
            GroupId = group.GroupId;
            Title = group.Title;
            OwnerId = group.OwnerId;
            Members = members;
        }
    }
}