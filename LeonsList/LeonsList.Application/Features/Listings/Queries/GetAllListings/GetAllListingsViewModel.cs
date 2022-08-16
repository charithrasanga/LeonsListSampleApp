using LeonsList.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeonsList.Application.Features.Listings.Queries.GetAllListings
{
   
    public class GetAllListingsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Category Category { get; set; }
        public bool IsPrivate { get; set; }

        public List<int> imageIds { get; set; }

        public GetAllListingsViewModel()
        {
            imageIds = new List<int>();
        }
    }
}
