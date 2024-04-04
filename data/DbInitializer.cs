using Laba3_4.models;
using System.Diagnostics;

namespace Laba3_4.data
{
    public static class DbInitializer
    {
        public static void Initialize(MyDbContext context)
        {
            // Look for any testimonials.
            if (context.Testimonials.Any())
            {
                return;   // DB has been seeded
            }

            var testimonials = new TestimonialService[]
            {
                new TestimonialService{name="James Fernando",img_url="uploads/testi_01.png",occupation="Manager of Racer",title=" Wonderful Support!",description="They have got my project on time with the competition with a sed highly skilled, and experienced & professional team."},
                new TestimonialService{name="Jacques Philips",img_url="uploads/testi_02.png",occupation="Designer",title="Awesome Services!",description="Explain to you how all this mistaken idea of denouncing pleasure and praising pain was born and I will give you completed."},
                new TestimonialService{name="Venanda Mercy",img_url="uploads/testi_03.png",occupation="Newyork City",title="Great & Talented Team!",description="The master-builder of human happines no one rejects, dislikes avoids pleasure itself, because it is very pursue pleasure."}        
            };

            context.Testimonials.AddRange(testimonials);
            context.SaveChanges();
        }
    }
}
