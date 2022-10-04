using System;
using System.Linq;
using System.Threading.Tasks;
using DeskApi.Configuration;
using DeskApi.Controllers;
using Meadow.Foundation.Web.Maple.Server;
using Meadow.Foundation.Web.Maple.Server.Routing;

namespace DeskApi.Handlers
{
    public class Desk : RequestHandlerBase
    {
        public Desk() { }

        [HttpGet("pins")]
        public async Task<IActionResult> GetPins()
        {
            Console.WriteLine("GET::Pins");
            

            Context.Response.ContentType = ContentTypes.Application_Json;
            Context.Response.StatusCode = 200;
            return await Task.FromResult(new OkObjectResult(DeskController.Current.Desks));
        }

        [HttpPost("{command}")]
        public async Task<IActionResult> Action(string command)
        {
            try
            {
                var (id, cmd, delay) = CommandParser.ParseCommand(command);
                var desk = DeskController.Current.Desks[id];
                if (desk == null) return new NotFoundResult();

                switch (cmd)
                {
                    case "lower":
                        await DeskController.Current.Lower(desk, delay);
                        break;
                    case "raise":
                        await DeskController.Current.Raise(desk, delay);
                        break;
                    case "stop":
                        DeskController.Current.Stop(desk);
                        break;
                }

                Context.Response.ContentType = ContentTypes.Application_Json;
                Context.Response.StatusCode = 200;
                return new OkResult();
            }
            catch (Exception ex)
            {
                return new ServerErrorResult(ex);
            }
        }
    }

    public class CommandParser
    {
        public static (int id, string command, double delay) ParseCommand(string cmd)
        {
            var parts = cmd.Split('-');
            var parsedInt = int.TryParse(parts.FirstOrDefault(), out var id);
            var cmdString = parts.Skip(1).FirstOrDefault();
            var parsedDouble = double.TryParse(parts.Skip(2).FirstOrDefault(), out var delay);
            if (!parsedInt)
            {
                throw new Exception();
            }

            if (!parsedDouble)
            {
                throw new Exception();
            }

            
            switch (cmd)
            {
                case "lower":
                    break;
                case "raise":
                    break;
                case "stop":
                    break;
                default:
                    throw new Exception();
            }

            return (id, cmd, delay);
        }
    }
}