using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace lab8.Objects
{
    public class DepartureTimeList
    {
        private List<IWebElement> _elements;
        
        public DepartureTimeList(List<IWebElement> webElements)
        {
            _elements = webElements;
        }

        public bool AreElementsInOrder()
        {
            var departureTimeTexts = _elements.Select(departureTime => departureTime.Text).ToList();
            var areTrainsInOrderOfDeparture = true;

            for (var i = 0; i < departureTimeTexts.Count - 1; i++)
            {
                var firstTrainDepartureHour = GetHour(departureTimeTexts[i]);
                var secondTrainDepartureHour = GetHour(departureTimeTexts[i + 1]);

                if (firstTrainDepartureHour > secondTrainDepartureHour)
                {
                    areTrainsInOrderOfDeparture = false;
                    break;
                }

                if (firstTrainDepartureHour == secondTrainDepartureHour)
                {
                    var firstTrainDepartureMinute = GetMinute(departureTimeTexts[i]);
                    var secondTrainDepartureMinute = GetMinute(departureTimeTexts[i + 1]);

                    if (firstTrainDepartureMinute > secondTrainDepartureMinute)
                    {
                        areTrainsInOrderOfDeparture = false;
                        break;
                    }
                }
            }

            return areTrainsInOrderOfDeparture;
        }

        private int GetHour(string departureTime)
        {
            return int.Parse(departureTime[..2]);
        }

        private int GetMinute(string departureTime)
        {
            return int.Parse(departureTime[3..]);
        }
    }
}