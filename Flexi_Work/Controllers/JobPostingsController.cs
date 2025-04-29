using Microsoft.AspNetCore.Mvc;
using Flexi_Work;
namespace Flexi_Work.Model;

[ApiController]
[Route("[controller]")]

public class JobPostingsController : ControllerBase
{

    
    [HttpGet(Name = "GetJobPosting")]
    public List<PostInfo> Get()
    {
        List<PostInfo> posts = new List<PostInfo>
        {
            new PostInfo
            {
                PostId = 1,
                PostTitle = "Looking for Guitarist",
                PostDescription = "Need a lead guitarist for a weekend bar gig in Paris.",
                PostContactDetails = "+33 612345678"
            },
            new PostInfo
            {
                PostId = 2,
                PostTitle = "Selling Old Amp",
                PostDescription = "Marshall 50W amp in great condition, barely used.",
                PostContactDetails = "+33 698765432"
            },
            new PostInfo
            {
                PostId = 3,
                PostTitle = "Band Rehearsal Space Available",
                PostDescription = "Hourly rental available in central Paris with full drum kit.",
                PostContactDetails = "+33 623456789"
            }
        };
        return posts;
    }

}