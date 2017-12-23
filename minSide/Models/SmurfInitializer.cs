using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;

namespace minSide.Models {
    public class SmurfInitializer : DropCreateDatabaseAlways<SmurfContext> {

        protected override void Seed(SmurfContext context) {
            base.Seed(context);
        }

        private byte[] getFileBytes(string path) {
            FileStream fileOnDisk = new FileStream(HttpRuntime.AppDomainAppPath + path, FileMode.Open);
            byte[] fileBytes;
            using (BinaryReader br = new BinaryReader(fileOnDisk)) {
                fileBytes = br.ReadBytes((int)fileOnDisk.Length);
            }
            return fileBytes;
        }
    }
}