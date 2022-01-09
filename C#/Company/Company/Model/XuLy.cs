using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    class XuLy
    {
        string id;
        string tinhTrangId;

        public XuLy(string id, string tinhTrangId)
        {
            this.id = id;
            this.tinhTrangId = tinhTrangId;
        }

        public string Id { get => id; set => id = value; }
        public string TinhTrangId { get => tinhTrangId; set => tinhTrangId = value; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;

            var xuLy = (XuLy)obj;

            return id.Equals(xuLy.id)
                   && tinhTrangId.Equals(xuLy.tinhTrangId);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
