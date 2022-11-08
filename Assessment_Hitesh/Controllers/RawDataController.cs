using Assessment_Hitesh.Data;
using Assessment_Hitesh.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Assessment_Hitesh.Controllers;

[ApiController]
[Route("[controller]")]
public class RawDataController: ControllerBase
{

    // define readonly properties for db and random 
    private readonly RawDataDBContext _rawDataDBContext;
    private readonly Random randomValue = new Random();
    public RawDataController(RawDataDBContext rawDataDBContext)
    {
        _rawDataDBContext = rawDataDBContext;
    }

    // Fetch the data according to given formula
    [HttpGet]
    public async Task<IActionResult> GetRawData()
    {
        var rawdataValues = await _rawDataDBContext.rawdata.ToListAsync();
        decimal count1 = 0;
        decimal count2 = 0;
        decimal count3 = 0;
        decimal count4 = 0;
        decimal count5 = 0;
        float finalResult = 0;

        foreach(var scorevalues in rawdataValues)
        {
            int currentValue = scorevalues.Score;
            switch (currentValue)
            {
                case 1:
                    count1 = count1 + 1;
                    break;
                case 2:
                    count2 = count2 + 1;
                    break;
                case 3:
                    count3 = count3 + 1;
                    break;
                case 4:
                    count4 = count4 + 1;
                    break;
                case 5:
                    count5 = count5 + 1;
                    break;
            }
        }
        finalResult = (float)Convert.ToDouble(((count4 + count5) / (count1 + count2 + count3 + count4 + count5)) * 100);
        return Ok(finalResult);
    }

    // To Submit the data into rawData Table
    [HttpPost]
    public void SubmitData(RawData rawDataValue)
    {
        try
        {
            // Create list to hold data for each iteration

            List<RawData> _rawData  = new List<RawData>();

            // Call 10 times and insert the random values to score between 1 to 5
            for (int i = 1; i <= 10; i++)
            {
                int score = randomValue.Next(1, 5);
                string strQ = rawDataValue.Question + "_" + score;
                
                rawDataValue.Question = strQ;
                rawDataValue.Score=score;

                _rawData.Add(new RawData { Question = strQ, Score = score });                
            }
            _rawDataDBContext.rawdata.AddRange(_rawData);  
            _rawDataDBContext.SaveChanges(true);
        }
        catch
        {
            throw;
        };
    }

}