using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCappLabs.BLL.Level1;
using MVCappLabs.BLL.Level2;
using MVCappLabs.DAL;
using MVCappLabs.Models.Level1;
using MVCappLabs.Models.Level2;
using MVCappLabs.Web.Models.AppLabs;
using MVCappLabs.Web.Views.AppLabs;


namespace MVCappLabs.Web.Controllers
{
    public class AppLabsController : Controller
    {
        //
        // GET: /AppLabs/
        public ActionResult Index()
        {
            return View();
        }

        //********Level 1 Labs **********

        public ActionResult TipCalculator()
        {
            var model = new TipCalculatorRequest();
            return View(model);
        }

        [HttpPost]
        public ActionResult TipCalculator(TipCalculatorRequest request)
        {
            if (ModelState.IsValid)
            {


                var calc = new TipCalculator();

                var tipData = new MVCappLabs.Models.Level1.TipCalculationRequest();
                tipData.MealCost = request.MealCost.Value;
                tipData.TipPercent = request.TipPercent.Value / 100;

                var response = calc.CalculateTip(tipData);
                
                return View("TipCalculatorResponse", response);
             
            }
            return View("TipCalculator");
        }
        public ActionResult FlooringCalculator()
        {
            var model = new FloorInputs();
            return View(model);
        }

        [HttpPost]
        public ActionResult FlooringCalculator(FloorInputs inputs)
        {
            if (ModelState.IsValid)
            {
                var calc = new FlooringCalculator();
                var floorData = new FloorCalculation();
                floorData.Width = inputs.Width.Value;
                //what does .Value do here?  allows nullabe decimal to convert to target type decimal?
                floorData.Length = inputs.Length.Value;
                floorData.CostPerUnit = inputs.CostPerUnit.Value;

                var result = calc.CalculateFloor(floorData);
                inputs.FlooringCost = result.FlooringCost;
                inputs.Area = result.Area;
                inputs.LaborCost = result.LaborCost;
                inputs.TotalCostEstimate = result.TotalCostEstimate;
                return View("FlooringCalculator", inputs);
            }
            else
            {
                return View("FlooringCalculator");
            }
        }

        public ActionResult LeapYears()
        {
            var model = new LeapYearSearchTool();
            return View(model);
        }

        [HttpPost]
        public ActionResult LeapYears(LeapYearSearchTool searchTool)
        {
            if (ModelState.IsValidField("EndYear") && searchTool.StartYear >= searchTool.EndYear)
            {
                ModelState.AddModelError("EndYear", "Please make sure your end date is later than your start date");
            }
            if (ModelState.IsValid)
            {
                var leapFinder = new LeapYearFinder();
                var leapYears = new LeapYears();

                leapYears.StartYear = searchTool.StartYear.Value;
                leapYears.EndYear = searchTool.EndYear.Value;

                var result = leapFinder.SearchForLeapYears(leapYears);

                searchTool.Years = result.Years;
                searchTool.IsPostback = true;
                return View("LeapYears", searchTool);

            }
            else
            {
                searchTool.Years = new List<int>(); //not sure why this is necessary but I get null ref exception on View without it.

                return View("LeapYears", searchTool);
            }
        }

        public ActionResult ReversingAString()
        {
            var model = new TwoWayString();
            return View("ReversingAString", model);
        }

        [HttpPost]
        public ActionResult ReversingAString(TwoWayString stringModel)
        {


            if (ModelState.IsValid)
            {
                var reverser = new StringReverser();
                var text = new StringBothWays();
                text.Original = stringModel.Forward;
                text = reverser.ReverseString(text);
                stringModel.Reversed = text.Backwards;
                return View("ReversingAString", stringModel);

            }

            return View("ReversingAString");
        }

        //*************Level 2 Labs***************
        public ActionResult CharacterCount()
        {
            var model = new CharacterCountTool();
            return View(model);
        }

        [HttpPost]
        public ActionResult CharacterCount(CharacterCountTool countTool)
        {
            if (ModelState.IsValid)
            {
                var charCounter = new CharacterCounter();
                var counts = new CharacterCounts();
                counts = charCounter.CountCharacters(countTool.TextInput);
                countTool.Consonants = counts.Consonants;
                countTool.ConsonantList = counts.ConsonantList;
                countTool.Vowels = counts.Vowels;
                countTool.VowelList = counts.VowelList;
                countTool.Ys = counts.Ys;
                countTool.Spaces = counts.Spaces;
                countTool.TotalCharacters = counts.TotalCharacters;
                countTool.Punctuation = counts.Punctuation;
                countTool.NonLetters = counts.NonLetters;
                return View("CharacterCount", countTool);
            }
            return View("CharacterCount");
        }

        public ActionResult Palindromes()
        {
            var model = new PalindromeTool();
            return View(model);
        }

        [HttpPost]
        public ActionResult Palindromes(PalindromeTool pt)
        {
            if (ModelState.IsValid)
            {
                var request = new PalindromeRequest();
                var evaluator = new PalindromeEvaluator();
                request.RawString = pt.RawString;
                request = evaluator.EvaluatePalindrome(request);
                if (request.IsPalindrome)
                {
                    pt.IsPalindrome = 1;
                }
                else
                {
                    pt.IsPalindrome = 2;
                }

                return View("Palindromes", pt);

            }
            return View("Palindromes");
        }

        public ActionResult Fibonacci()
        {
            var model = new FibonacciTool();
            return View(model);
        }

        [HttpPost]
        public ActionResult Fibonacci(FibonacciTool ft)
        {
            if (ModelState.IsValid)
            {
                var generator = new FibonacciGenerator();
                var fibonacciList = generator.FindFibs(ft.NumberOfFibs.Value);
                ft.FibonacciList = fibonacciList;
                return View("Fibonacci", ft);
            }
            ft.FibonacciList = new List<ulong>();
            return View("Fibonacci", ft);
        }

        public ActionResult NextPrime()
        {
            var model = new PrimeSearchTool();
            return View(model);
        }

        [HttpPost]
        public ActionResult NextPrime(PrimeSearchTool number)
        {
            if (ModelState.IsValid)
            {
                var primeFinder = new PrimeFinder();
                var primer = new Primer();
                primer.StartNumber = number.FirstNumber.Value;
                primer = primeFinder.FindPrime(primer);
                number.NextPrime = primer.PrimeNumber;
                return View("NextPrime", number);
            }
            return View("NextPrime", number);
        }

        public ActionResult VendingMachine()
        {
            var model = new VendingTool();
            var vr = new VendingRepository();
         //   model.Items = vr.LoadItemsFromFile(); since I can't get my filereader to find my txt file, I'm filling a dummy list
            var itemList = new List<VendingItem> //Hard coded until I can figure out how to get filereader to find my txt file.
            {
                new VendingItem() {Name = "Starburst - $1.25", Price = 1.25M},
                new VendingItem() {Name = "French Fries - $2.05", Price = 2.05M},
                new VendingItem() {Name = "Butterfingers - $1.25", Price = 1.25M},
                new VendingItem() {Name = "Puppy - $0.89", Price = .89M}

            };
            model.Items = itemList;
            return View(model);
        }

        [HttpPost]
        public ActionResult VendingMachine(VendingTool model)
        {
            if (ModelState.IsValid)
            {//need to add validation for insufficient funds
               
                var request = new ChangeRequest();
                request.Payment = (int)(model.Payment.Value*100);
                request.Price = (int)(model.Item.Price*100);
                request.ChangeOwed =request.Payment-request.Price;
                var cm = new ChangeMaker();
              var response=  cm.MakeChange(request);
                return View("VendingResult", response);
            }

            var itemList = new List<VendingItem> //Hard coded until I can figure out how to get filereader to find my txt file.
            {
                new VendingItem() {Name = "Starburst - $1.25", Price = 1.25M},
                new VendingItem() {Name = "French Fries - $2.05", Price = 2.05M},
                new VendingItem() {Name = "Butterfingers - $1.25", Price = 1.35M},
                new VendingItem() {Name = "Puppy - $0.89", Price = .89M}

            };
            model.Items = itemList;

            return View("VendingMachine", model);
        }
    }

}