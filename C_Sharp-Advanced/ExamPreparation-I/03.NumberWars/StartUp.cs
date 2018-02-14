using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.NumberWars
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var firstAllCards = new Queue<string>(Console.ReadLine().Split());
            var secondAllCards = new Queue<string>(Console.ReadLine().Split());

            var turnCount = 0;
            bool gameOver = false;

            while (turnCount < 1_000_000 && firstAllCards.Count > 0 && secondAllCards.Count > 0 && !gameOver) 
            {
                var firstCard = firstAllCards.Dequeue();
                var secondCard = secondAllCards.Dequeue();

                if (GetNumber(firstCard)>GetNumber(secondCard))
                {
                    firstAllCards.Enqueue(firstCard);
                    firstAllCards.Enqueue(secondCard);
                }
                else if (GetNumber(firstCard)<GetNumber(secondCard))
                {
                    secondAllCards.Enqueue(secondCard);
                    secondAllCards.Enqueue(firstCard);
                }
                else
                {
                    var cardsHand = new List<string> { firstCard,secondCard};
                    while (!gameOver)
                    {
                        if (firstAllCards.Count>=3&& secondAllCards.Count>=3)
                        {
                            int firstSum = 0;
                            int secondSum = 0;
                            for (int i = 0; i <3; i++)
                            {
                                var currentFirstHandCard = firstAllCards.Dequeue();
                                var currentSecondHandCard = secondAllCards.Dequeue();

                                firstSum += GetChar(currentFirstHandCard);
                                secondSum += GetChar(currentSecondHandCard);

                                cardsHand.Add(currentFirstHandCard);
                                cardsHand.Add(currentSecondHandCard);
                            }
                            if (firstSum>secondSum)
                            {
                                AddCartToWinner(cardsHand,firstAllCards);
                                break;
                            }
                            else if (secondSum>firstSum)
                            {
                                AddCartToWinner(cardsHand, secondAllCards);
                                break;
                            }
                        }
                        else
                        {
                            gameOver = true;
                        } 
                    }
                }
                turnCount++;
            }
            var result = string.Empty;

            if (firstAllCards.Count == secondAllCards.Count)
                result = "Draw";
            else if (firstAllCards.Count > secondAllCards.Count)
                result = "First player wins";
            else
                result = "Second player wins";

            Console.WriteLine($"{result} after {turnCount} turns");
        }

        private static void AddCartToWinner(List<string> cardsHand, Queue<string> allCards)
        {
            foreach (var card in cardsHand
                                .OrderByDescending(c=>GetNumber(c))
                                .ThenByDescending(c=>GetChar(c)))
            {
                allCards.Enqueue(card);
            }
        }

        static int GetNumber(string card)
        {
            return int.Parse(card.Substring(0, card.Length - 1));
        }
        static int GetChar(string card)
        {
            return card[card.Length - 1];
        }
    }
}
