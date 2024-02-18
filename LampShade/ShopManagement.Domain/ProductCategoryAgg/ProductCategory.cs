using _0_Framework.Domain;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public class ProductCategory:EntityBase
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Picture { get; private set; }
        public string PictureTitle { get; private set; }
        public string PictureAlt { get; private set; }
        public string Keywords { get; private set; }
        public string MetaDescription { get; private set; } 
        public string Slug { get; private set; }

        //public string Name { get;  set; }
        //public string Description { get;  set; }
        //public string Picture { get;  set; }
        //public string PictureTitle { get;  set; }
        //public string PictureAlt { get;  set; }
        //public string Slug { get;  set; }


        public ProductCategory(string name, string description, string picture, string pictureTitle,
            string pictureAlt, string keywords, string metaDescription, string slug)
        {
            Name = name;
            Description = description;
            Picture = picture;
            PictureTitle = pictureTitle;
            PictureAlt = pictureAlt;
            Keywords = keywords;
            MetaDescription = metaDescription;
            Slug = slug;
        }


        /// <summary>
        /// Matt Says:
        /// this is not a good idea to pass multi fields istead of a model to Edit (or any similar method.
        /// I should change it ASAP.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="picture"></param>
        /// <param name="pictureTitle"></param>
        /// <param name="pictureAlt"></param>
        /// <param name="keywords"></param>
        /// <param name="metaDescription"></param>
        /// <param name="slug"></param>

        public void Edit(string name, string description, string picture, string pictureTitle,
            string pictureAlt, string keywords, string metaDescription, string slug)
        {
            Name = name;
            Description = description;
            Picture = picture;
            PictureTitle = pictureTitle;
            PictureAlt = pictureAlt;
            Keywords = keywords;
            MetaDescription = metaDescription;
            Slug = slug;
        }


    }



}
