using System.ComponentModel.DataAnnotations;

namespace KeyVault.Models.GroupMember
{
    public class GroupMemberForCreation
    {
        [MaxLength(250)]
        public string GroupId { get; set; }

        [MaxLength(250)]
        public string MemberId { get; set; }

        public GroupMemberForCreation() { }

        public GroupMemberForCreation(string groupId, string memberId)
        {
            GroupId = groupId;
            MemberId = memberId;
        }
    }
}