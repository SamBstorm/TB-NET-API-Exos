using API_Exo01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Exo01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MathController : ControllerBase
    {
        [HttpGet]
        [Route("{nb1}/plus/{nb2}")]
        [Route("{nb1}/{nb2}")]
        public string GetAddition(int nb1, int nb2)
        {
            return $"{nb1} + {nb2} = {nb1 + nb2}";
        }

        [HttpPost]
        public bool PostCheckOperation(MathOperation operation)
        {
            int result = 0;
            try
            {
                switch (operation.Operator)
                {
                    case "+":
                        result = operation.Nb1 + operation.Nb2;
                        break;
                    case "-":
                        result = operation.Nb1 - operation.Nb2;
                        break;
                    case "*":
                        result = operation.Nb1 * operation.Nb2;
                        break;
                    case "/":
                        result = operation.Nb1 / operation.Nb2;
                        break;
                    default:
                        return false;
                        break;
                }
            }
            catch (Exception) 
            { 
                return false;
            }
            return operation.Result == result;
        }

        [HttpGet("Loop/{nb:int:min(0)}")]
        public IEnumerable<int> GetLoop(int nb)
        {
            List<int> result = new List<int>();
            for (int i = 0; i <= nb; i++)
            {
                result.Add(i);
            }
            return result;
        }
    }
}
