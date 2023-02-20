using Sodimac.SCPRO.Model.Interface;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sodimac.SCPRO.Model.Master
{
    public class Canal : AuditBase, IGenerateIdentity<Canal>
    {
        public int CanalId { get; set; }
        [MaxLength(4)]
        [Required]
        public string Codigo { get; set; }
        [MaxLength(50)]
        [Required]
        public string Nombre { get; set; }
        public Func<Canal> GetKey()
        {
            return () => new Canal() { CanalId = CanalId };
        }
    }
}
