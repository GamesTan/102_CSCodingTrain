using System.Collections.Generic;

namespace GamesTan.Lec03_CmdGame {


    public class RenderInfos {
        private List<RenderInfo> infos = new List<RenderInfo>();

        public void AddInfo(RenderInfo info) {
            infos.Add(info);
        }
        public List<RenderInfo> GetInfos() {
            return infos;
        }
    }

}
