using System;
using System.Collections.Generic;
using MvcSiteMapProvider;
using System.Linq;
using System.Web;

namespace minSide.Models
{
    public class PhotoDynamicNodeProvider : DynamicNodeProviderBase
    {
        SmurfContext context = new SmurfContext();

        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            List<DynamicNode> returnList = new List<DynamicNode>();

            foreach (Photo item in context.Photos)
            {
                DynamicNode newNode = new DynamicNode();
                newNode.Title = item.Title;
                newNode.ParentKey = "AllPhotos";
                newNode.RouteValues.Add("id", item.PhotoID);
                returnList.Add(newNode);
            }

            return returnList;
        }
    }
}