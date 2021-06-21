using System.Collections.Generic;

namespace GamesTan.Lec03_CmdGame {


    public class RenderInfos {
        private List<RenderInfo> infos = new List<RenderInfo>();
        private List<object> extraInfos = new List<object>();
        public void AddExtInfos<T>(IEnumerable<T> objs) {
            foreach (var item in objs) {
                extraInfos.Add(item);
            }
        }
        public List<object> GetExtInfos() {
            return extraInfos;
        }

        public void AddInfo(RenderInfo info) {
            infos.Add(info);
        }
        public List<RenderInfo> GetInfos() {
            return infos;
        }
    }

}
