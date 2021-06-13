using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ProductReviewManagementWithLinq
{

    class Management
    {
        public readonly DataTable dataTable = new DataTable();
        public void TopRecords(List<ProductReview> listProductReview)
        {
            var recordedData = (from productReviews in listProductReview
                                orderby productReviews.Rating descending
                                select productReviews).Take(3);

            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductID:- " + list.ProducID + " " + "UserID:- " + list.UserID
                    + " " + "Rating:- " + list.Rating + " " + "Review:- " + list.Review + " " + "isLike:- " + list.isLike);
            }

        }

        public void SelectedRecords(List<ProductReview> listProductReview)
        {
            var recordedData = from productReviews in listProductReview
                               where (productReviews.ProducID == 1 || productReviews.ProducID == 4 || productReviews.ProducID == 9)
                               && productReviews.Rating > 3
                               select productReviews;
            Console.WriteLine(recordedData);
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductID:- " + list.ProducID + " " + "UserID:- " + list.UserID
                    + " " + "Rating:- " + list.Rating + " " + "Review:- " + list.Review + " " + "isLike:- " + list.isLike);
            }

        }

        public void RetrieveCountOfRecords(List<ProductReview> listProductReview)
        {
            var recordedData = listProductReview.GroupBy(y => y.ProducID).Select(x => new { ProductID = x.Key, Count = x.Count() });


            foreach (var list in recordedData)
            {
                Console.WriteLine(list.ProductID + "--------" + list.Count);

            }
        }
        public void RetrieveProductIDAndReviews(List<ProductReview> listProductReview)
        {
            var recordedData = from productReview in listProductReview
                               select new { productReview.ProducID, productReview.Review };
            foreach (var list in recordedData)
            {
                Console.WriteLine("Product id: " + list.ProducID + " " + "Review: " + list.Review);
            }
        }
        public void SkipTopFiveRecords(List<ProductReview> listProductReview)
        {
            var recordedData = (from productReview in listProductReview
                                orderby productReview.ProducID
                                select productReview).Skip(5);
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductId: " + list.ProducID + " UserId: " + list.UserID + " Rating: " + list.Rating +
                    " Review: " + list.Review + " IsLike: " + list.isLike);
            }
        }
        public void SelectProductIDAndReviews(List<ProductReview> listProductReview)
        {
            var recordedData = listProductReview.Select(x => new { x.ProducID, x.Review });
            foreach (var list in recordedData)
            {
                Console.WriteLine("Product ID: " + list.ProducID + " " + "Review: " + list.Review);
            }
        }
        public Management()
        {
            /// Creating columns
            dataTable.Columns.Add("ProductId", typeof(int));
            dataTable.Columns.Add("UserId", typeof(int));
            dataTable.Columns.Add("Rating", typeof(int));
            dataTable.Columns.Add("Review", typeof(string));
            dataTable.Columns.Add("isLike", typeof(bool));

            /// Creating rows and adding values 
            dataTable.Rows.Add(1, 1, 5, "good", "true");
            dataTable.Rows.Add(2, 2, 3, "better", "true");
            dataTable.Rows.Add(3, 3, 5, "good", "true");
            dataTable.Rows.Add(4, 4, 4, "nice", "true");
            dataTable.Rows.Add(5, 5, 3, "better", "true");
            dataTable.Rows.Add(6, 6, 5, "good", "false");
            dataTable.Rows.Add(7, 7, 5, "good", "true");
            dataTable.Rows.Add(8, 7, 5, "better", "true");
            dataTable.Rows.Add(9, 8, 3, "good", "true");
            dataTable.Rows.Add(10, 9, 5, "good", "true");
            dataTable.Rows.Add(11, 10, 3, "better", "true");
            dataTable.Rows.Add(12, 10, 4, "nice", "false");
            dataTable.Rows.Add(13, 11, 3, "better", "true");
            dataTable.Rows.Add(14, 11, 4, "good", "true");
            dataTable.Rows.Add(15, 11, 5, "good", "true");
            dataTable.Rows.Add(16, 11, 5, "good", "true");
            dataTable.Rows.Add(17, 11, 3, "better", "true");
            dataTable.Rows.Add(18, 12, 4, "nice", "true");
            dataTable.Rows.Add(19, 15, 5, "good", "true");
            dataTable.Rows.Add(20, 16, 5, "good", "true");
            dataTable.Rows.Add(21, 17, 5, "good", "true");
            dataTable.Rows.Add(22, 11, 4, "nice", "true");
            dataTable.Rows.Add(23, 18, 3, "better", "false");
            dataTable.Rows.Add(24, 19, 4, "nice", "true");
            dataTable.Rows.Add(25, 20, 4, "nice", "true");
        }
        public void RetrieveTrueIsLike()
        {
            var Data = from reviews in dataTable.AsEnumerable()
                       where reviews.Field<bool>("isLike").Equals(true)
                       select reviews;
            foreach (var dataItem in Data)
            {
                Console.WriteLine($"ProductID- {dataItem.ItemArray[0]} UserID- {dataItem.ItemArray[1]} Rating- {dataItem.ItemArray[2]} Review- {dataItem.ItemArray[3]} isLike- {dataItem.ItemArray[4]}");
            }
        }
    }
}
