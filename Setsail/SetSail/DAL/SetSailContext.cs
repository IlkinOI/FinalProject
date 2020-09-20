using SetSail.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SetSail.DAL
{
    public class SetSailContext:DbContext
    {
        public SetSailContext() : base("SetSailConnect")
        {

        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<BlogComment> BlogComments { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactCity> ContactCities { get; set; }
        public DbSet<ContactCountry> ContactCountries { get; set; }
        public DbSet<ContactReply> contactReplies { get; set; }
        public DbSet<ContactSocial> ContactSocials { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<DayInclude> DayIncludes { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<DesToCat> DesToCats { get; set; }
        public DbSet<DesToType> DesToTypes { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<Include> Includes { get; set; }
        public DbSet<NotInclude> NotIncludes { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamSocial> TeamSocials { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<TourCategory> TourCategories { get; set; }
        public DbSet<TourCity> TourCities { get; set; }
        public DbSet<TourImage> TourImages { get; set; }
        public DbSet<TourReview> TourReviews { get; set; }
        public DbSet<TourType> TourTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserSocial> UserSocials { get; set; }
        public DbSet<WinterPage> WinterPages { get; set; }
        public DbSet<SummerPage> SummerPages { get; set; }
        public DbSet<WinePage> WinePages { get; set; }
        public DbSet<CityPage> CityPages { get; set; }
        public DbSet<ExoticPage> ExoticPages { get; set; }
        public DbSet<HomePage> HomePages { get; set; }
        public DbSet<TourDates> TourDates { get; set; }

    }
}