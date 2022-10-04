using DeskApi;
using DeskApi.Configuration;
using DeskApi.Controllers;
using FluentAssertions;

namespace TestProject1;

public class Tests
{
    private DeskSettings _deskSettings;
    private DeskController _deskController;
    [SetUp]
    public void Setup()
    {
        _deskSettings = new DeskSettings
        {
            DeskPins = new List<DeskPins>
            {
                new DeskPins
                {
                    DownPin = "D05",
                    UpPin = "D06"
                },
                new DeskPins
                {
                    DownPin = "D07",
                    UpPin = "D08"
                }
            }
        };
        DeskController.Current.Initialize(_deskSettings);
        _deskController = DeskController.Current;
    }

    [Test]
    public void Test1()
    {
        
        _deskController.Desks.Should().HaveCount(2);
    }
}