﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using System.Diagnostics;
using System.Collections;

namespace EnumerableTask
{

    public class Task
    {
        /// <summary> Transforms all strings to uppercase</summary>
        /// <param name="data">source string sequence</param>
        /// <returns>
        ///   Returns sequence of source strings in uppercase
        /// </returns>
        /// <example>
        ///    {"a","b","c"} => { "A", "B", "C" }
        ///    { "A", "B", "C" } => { "A", "B", "C" }
        ///    { "a", "A", "", null } => { "A", "A", "", null }
        /// </example>
        public IEnumerable<string> GetUppercaseStrings(IEnumerable<string> data)
        {
            // TODO : Implement GetUppercaseStrings
            var result = data.ToList();

            foreach (var item in result)
            {
                if (string.IsNullOrEmpty(item))
                {
                    return data;
                }
            }

            result = result.ConvertAll(x => x.ToUpper());

            return result;
        }

        /// <summary> Transforms an each string from sequence to its length</summary>
        /// <param name="data">source strings sequence</param>
        /// <returns>
        ///   Returns sequence of strings length
        /// </returns>
        /// <example>
        ///   { } => { }
        ///   {"a","aa","aaa" } => { 1, 2, 3 }
        ///   {"aa","bb","cc", "", "  ", null } => { 2, 2, 2, 0, 2, 0 }
        /// </example>
        public IEnumerable<int> GetStringsLength(IEnumerable<string> data)
        {
            // TODO : Implement GetStringsLength

            var list = data.ToList();

            IEnumerable<int> result = list.Select(x =>
                                                 {
                                                     if (x == null)
                                                         return 0;
                                                     else
                                                         return
                                                         x.Length;
                                                 });

            return result;
        }

        /// <summary>Transforms int sequence to its square sequence, f(x) = x * x </summary>
        /// <param name="data">source int sequence</param>
        /// <returns>
        ///   Returns sequence of squared items
        /// </returns>
        /// <example>
        ///   { } => { }
        ///   { 1, 2, 3, 4, 5 } => { 1, 4, 9, 16, 25 }
        ///   { -1, -2, -3, -4, -5 } => { 1, 4, 9, 16, 25 }
        /// </example>
        public IEnumerable<long> GetSquareSequence(IEnumerable<int> data)
        {
            // TODO : Implement GetSquareSequence
            var list = data.ToList();

            IEnumerable<long> result = list.Select(x => x * (long)x);

            return result;
        }

        /// <summary>Transforms int sequence to its moving sum sequence, 
        ///          f[n] = x[0] + x[1] + x[2] +...+ x[n] 
        ///       or f[n] = f[n-1] + x[n]   
        /// </summary>
        /// <param name="data">source int sequence</param>
        /// <returns>
        ///   Returns sequence of sum of all source items with less or equals index
        /// </returns>
        /// <example>
        ///   { } => { }
        ///   { 1, 1, 1, 1 } => { 1, 2, 3, 4 }
        ///   { 5, 5, 5, 5 } => { 5, 10, 15, 20 }
        ///   { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 } => { 1, 3, 6, 10, 15, 21, 28, 36, 45, 55 }
        ///   { 1, -1, 1, -1, -1 } => { 1, 0, 1, 0, 1 }
        /// </example>
        public IEnumerable<long> GetMovingSumSequence(IEnumerable<int> data)
        {
            // TODO : Implement GetMovingSumSequence
            var list = data.ToList();

            long sum = 0;

            IEnumerable<long> result = list.Select((x, y) =>
            {
                if (y == 0)
                {
                    sum = x;
                    return sum;
                }
                else
                {
                    sum += x;
                    return sum;
                }

            });

            return result;
        }


        /// <summary> Filters a string sequence by a prefix value (case insensitive)</summary>
        /// <param name="data">source string sequence</param>
        /// <param name="prefix">prefix value to filter</param>
        /// <returns>
        ///  Returns items from data that started with required prefix (case insensitive)
        /// </returns>
        /// <exception cref="System.ArgumentNullException">prefix is null</exception>
        /// <example>
        ///  { "aaa", "bbbb", "ccc", null }, prefix="b"  =>  { "bbbb" }
        ///  { "aaa", "bbbb", "ccc", null }, prefix="B"  =>  { "bbbb" }
        ///  { "a","b","c" }, prefix="D"  => { }
        ///  { "a","b","c" }, prefix=""   => { "a","b","c" }
        ///  { "a","b","c", null }, prefix=""   => { "a","b","c" }
        ///  { "a","b","c" }, prefix=null => exception
        /// </example>
        public IEnumerable<string> GetPrefixItems(IEnumerable<string> data, string prefix)
        {
            // TODO : Implement GetPrefixItems
            if (prefix is null)
            {
                throw new ArgumentNullException("prefix is null");
            }

            var list = data.ToList();

            var result = list.Where(x => x != null && x.StartsWith(prefix.ToLower()));

            return result;
        }

        /// <summary> Returns every second item from source sequence</summary>
        /// <typeparam name="T">the type of the elements of data</typeparam>
        /// <param name="data">source sequence</param>
        /// <returns>Returns a subsequence that consists of every second item from source sequence</returns>
        /// <example>
        ///  { 1,2,3,4,5,6,7,8,9,10 } => { 2,4,6,8,10 }
        ///  { "a","b","c" , null } => { "b", null }
        ///  { "a" } => { }
        /// </example>
        public IEnumerable<T> GetEvenItems<T>(IEnumerable<T> data)
        {
            // TODO : Implement GetEvenItems


            var list = data.ToList();

            var result = list.Where((x, y) => y % 2 != 0);

            return result;
        }

        /// <summary> Propagate every item in sequence its position times</summary>
        /// <typeparam name="T">the type of the elements of data</typeparam>
        /// <param name="data">source sequence</param>
        /// <returns>
        ///   Returns a sequence that consists of: one first item, two second items, tree third items etc. 
        /// </returns>
        /// <example>
        ///   { } => { }
        ///   { 1 } => { 1 }
        ///   { "a","b" } => { "a", "b","b" }
        ///   { "a", "b", "c", null } => { "a", "b","b", "c","c","c", null,null,null,null }
        ///   { 1,2,3,4,5} => { 1, 2,2, 3,3,3, 4,4,4,4, 5,5,5,5,5 }
        /// </example>
        public IEnumerable<T> PropagateItemsByPositionIndex<T>(IEnumerable<T> data)
        {
            // TODO : Implement PropagateItemsByPositionIndex
            if (data.Count() == 0)
            {
                return Enumerable.Empty<T>();
            }

            if (data.Count() == 1)
            {
                return data;
            }

            var list = data.ToList();

            List<T> result = new List<T>();

            for (int i = 0; i < list.Count(); i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    result.Add(list[i]);
                }
            }

            return result;
        }

        /// <summary>Finds all used char in string sequence</summary>
        /// <param name="data">source string sequence</param>
        /// <returns>
        ///   Returns set of chars used in string sequence.
        ///   Order of result does not matter.
        /// </returns>
        /// <example>
        ///   { "aaa", "bbb", "cccc", "abc" } => { 'a', 'b', 'c' } or { 'c', 'b', 'a' }
        ///   { " ", null, "   ", "" } => { ' ' }
        ///   { "", null } => { }
        ///   { } => { }
        /// </example>
        public IEnumerable<char> GetUsedChars(IEnumerable<string> data)
        {
            // TODO : Implement GetUsedChars
            var list = string.Join("", data.ToList());

            var result = list.Distinct();

            return result;
        }


        /// <summary> Converts a source sequence to a string</summary>
        /// <typeparam name="T">the type of the elements of data</typeparam>
        /// <param name="data">source sequence</param>
        /// <returns>
        ///   Returns a string respresentation of source sequence 
        /// </returns>
        /// <example>
        ///   { } => ""
        ///   { 1,2,3 } => "1,2,3"
        ///   { "a", "b", "c", null, ""} => "a,b,c,null,"
        ///   { "", "" } => ","
        /// </example>
        public string GetStringOfSequence<T>(IEnumerable<T> data)
        {
            // TODO : Implement GetStringOfSequence
            if (data.Count() == 0)
            {
                return string.Empty;
            }

            string result = string.Empty;

            foreach (var item in data)
            {
                if (item == null)
                {
                    result += "null" + ",";
                }
                else
                {
                    result += item + ",";
                }
            }

            var result1 = result.Remove(result.Length - 1, 1);

            return result1;
        }

        /// <summary> Finds the 3 largest numbers from a sequence</summary>
        /// <param name="data">source sequence</param>
        /// <returns>
        ///   Returns the 3 largest numbers from a sequence
        /// </returns>
        /// <example>
        ///   { } => { }
        ///   { 1, 2 } => { 2, 1 }
        ///   { 1, 2, 3 } => { 3, 2, 1 }
        ///   { 1,2,3,4,5,6,7,8,9,10 } => { 10, 9, 8 }
        ///   { 10, 10, 10, 10 } => { 10, 10, 10 }
        /// </example>
        public IEnumerable<int> Get3TopItems(IEnumerable<int> data)
        {
            // TODO : Implement Get3TopItems
            if (data.Count() == 0)
            {
                return Enumerable.Empty<int>();
            }

            if (data.Count() < 3)
            {
                return data.Reverse();
            }

            var max1 = data.OrderByDescending(x => x).Take(3);

            return max1;
        }

        /// <summary> Calculates the count of numbers that are greater then 10</summary>
        /// <param name="data">source sequence</param>
        /// <returns>
        ///   Returns the number of items that are > 10
        /// </returns>
        /// <example>
        ///   { } => 0
        ///   { 1, 2, 10 } => 0
        ///   { 1, 2, 3, 11 } => 1
        ///   { 1, 20, 30, 40 } => 3
        /// </example>
        public int GetCountOfGreaterThen10(IEnumerable<int> data)
        {
            // TODO : Implement GetCountOfGreaterThen10
            if (data.Count() == 0)
            {
                return 0;
            }

            var result = data.Where(x => x > 10);

            return result.Count();
        }


        /// <summary> Find the first string that contains "first" (case insensitive search)</summary>
        /// <param name="data">source sequence</param>
        /// <returns>
        ///   Returns the first string that contains "first" or null if such an item does not found.
        /// </returns>
        /// <example>
        ///   { "a", "b", null} => null
        ///   { "a", "IT IS FIRST", "first item", "I am really first!" } => "IT IS FIRST"
        ///   { } => null
        /// </example>
        public string GetFirstContainsFirst(IEnumerable<string> data)
        {
            // TODO : Implement GetFirstContainsFirst
            var result = data.Where(x => x != null && x.ToLower().Contains("first")).Take(1);

            return result.Count() == 0 ? null : result.ToList()[0].ToString();
        }

        /// <summary> Counts the number of unique strings with length=3 </summary>
        /// <param name="data">source sequence</param>
        /// <returns>
        ///   Returns the number of unique strings with length=3.
        /// </returns>
        /// <example>
        ///   { "a", "b", null, "aaa"} => 1    ("aaa")
        ///   { "a", "bbb", null, "", "ccc" } => 2  ("bbb","ccc")
        ///   { "aaa", "aaa", "aaa", "bbb" } => 2   ("aaa", "bbb") 
        ///   { } => 0
        /// </example>
        public int GetCountOfStringsWithLengthEqualsTo3(IEnumerable<string> data)
        {
            // TODO : Implement GetCountOfStringsWithLengthEqualsTo3
            if (data.Count() == 0)
            {
                return 0;
            }

            var result = data.Where(x => x != null && x.Length == 3).Distinct();

            return result.Count() == 0 ? 0 : result.Count();
        }

        /// <summary> Counts the number of each strings in sequence </summary>
        /// <param name="data">source sequence</param>
        /// <returns>
        ///   Returns the list of strings and number of occurence for each string.
        /// </returns>
        /// <example>
        ///   { "a", "b", "a", "aa", "b"} => { ("a",2), ("b",2), ("aa",1) }    
        ///   { "a", "a", null, "", "ccc", "" } => { ("a",2), (null,1), ("",2), ("ccc",1) }
        ///   { "aaa", "aaa", "aaa" } =>  { ("aaa", 3) } 
        ///   { } => { }
        /// </example>
        public IEnumerable<Tuple<string, int>> GetCountOfStrings(IEnumerable<string> data)
        {
            // TODO : Implement GetCountOfStrings
            var result = data.GroupBy(x => x).Select(x => new Tuple<string, int>(x.Key, x.Count()));

            return result;
        }

        /// <summary> Counts the number of strings with max length in sequence </summary>
        /// <param name="data">source sequence</param>
        /// <returns>
        ///   Returns the number of strings with max length. (Assuming that null has Length=0).
        /// </returns>
        /// <example>
        ///   { "a", "b", "a", "aa", "b"} => 1 
        ///   { "a", "aaa", null, "", "ccc", "" } => 2   
        ///   { "aaa", "aaa", "aaa" } =>  3
        ///   { "", null, "", null } => 4
        ///   { } => { }
        /// </example>
        public int GetCountOfStringsWithMaxLength(IEnumerable<string> data)
        {
            // TODO : Implement GetCountOfStringsWithMaxLength
            if (data.Count() == 0)
            {
                return 0;
            }

            if (data.Count() == 0)
            {
                return 0;
            }

            var dataEmpty = data.Select(x => string.IsNullOrEmpty(x)).Where(x => x == true); ;

            if (dataEmpty.Count() == data.Count())
            {
                return dataEmpty.Count();
            }

            var resuit = data.OfType<string>()
                .Where(x => !string.IsNullOrEmpty(x))
                .OrderByDescending(x => x.Length)
                .Select(x => x.Count())
                .GroupBy(x => x)
                .Take(1);

            var result1 = resuit.ToList();

            //var xxx = result1.Count() == 0 ? 0 : result1[0].ToList().Count();

            return result1.Count() == 0 ? 0 : result1[0].ToList().Count();
        }



        /// <summary> Counts the digit chars in a string</summary>
        /// <param name="data">source string</param>
        /// <returns>
        ///   Returns number of digit chars in the string
        /// </returns>
        /// <exception cref="System.ArgumentNullException">data is null</exception>
        /// <example>
        ///    "aaaa" => 0
        ///    "1234" => 4
        ///    "A1*B2" => 2
        ///    "" => 0
        ///    null => exception
        /// </example>
        public int GetDigitCharsCount(string data)
        {
            // TODO : Implement GetDigitCharsCount
            if (data is null)
            {
                throw new ArgumentNullException("exception");
            }

            var arr = data.ToCharArray();

            int result = 0;

            foreach (var item in arr)
            {
                if (char.IsDigit(item))
                {
                    result++;
                }
            }

            return result;
        }



        /// <summary>Counts the system log events of required type</summary>
        /// <param name="value">the type of log event (Error, Event, Information etc)</param>
        /// <returns>
        ///   Returns the number of System log entries of specified type
        /// </returns>
        public int GetSpecificEventEntriesCount(EventLogEntryType value)
        {
            // TODO : Implement GetSpecificEventEntriesCount
            EventLogEntryCollection systemEvents = (new EventLog("System", ".")).Entries;

            var result = systemEvents.Cast<EventLogEntry>().Count(x => x.EntryType.Equals(value));

            return result;
        }


        /// <summary> Finds all exported types names which implement IEnumerable</summary>
        /// <param name="assembly">the assembly to search</param>
        /// <returns>
        ///   Returns the names list of exported types implemented IEnumerable from specified assembly
        /// </returns>
        /// <exception cref="System.ArgumentNullException">assembly is null</exception>
        /// <example>
        ///    mscorlib => { "ApplicationTrustCollection","Array","ArrayList","AuthorizationRuleCollection",
        ///                  "BaseChannelObjectWithProperties", ... }
        ///    
        /// </example>
        public IEnumerable<string> GetIEnumerableTypesNames(Assembly assembly)
        {
            // TODO : Implement GetIEnumerableTypesNames
            if (assembly is null)
            {
                throw new ArgumentNullException("Exception!");
            }

            var result = assembly.ExportedTypes.Where(x => x.GetInterfaces().Contains(typeof(IEnumerable))).Select(x => x.Name).Distinct();

            return result;
        }

        /// <summary>Calculates sales sum by quarter</summary>
        /// <param name="sales">the source sales data : Item1 is sales date, Item2 is amount</param>
        /// <returns>
        ///     Returns array of sales sum by quarters, 
        ///     result[0] is sales sum for Q1, result[1] is sales sum for Q2 etc  
        /// </returns>
        /// <example>
        ///    {} => { 0, 0, 0, 0}
        ///    {(1/1/2010, 10)  , (2/2/2010, 10), (3/3/2010, 10) } => { 30, 0, 0, 0 }
        ///    {(1/1/2010, 10)  , (4/4/2010, 10), (10/10/2010, 10) } => { 10, 10, 0, 10 }
        /// </example>
        public int[] GetQuarterSales(IEnumerable<Tuple<DateTime, int>> sales)
        {
            // TODO : Implement GetQuarterSales
            var result = sales.Aggregate(new int[4], (x, y) => { x[((y.Item1.Month + 2) / 3) - 1] += y.Item2; return x; });

            return result;
        }

        /// <summary> Sorts string by length and alphabet </summary>
        /// <param name="data">the source data</param>
        /// <returns>
        /// Returns sequence of strings sorted by length and alphabet
        /// </returns>
        /// <example>
        ///  {} => {}
        ///  {"c","b","a"} => {"a","b","c"}
        ///  {"c","cc","b","bb","a,"aa"} => {"a","b","c","aa","bb","cc"}
        /// </example>
        public IEnumerable<string> SortStringsByLengthAndAlphabet(IEnumerable<string> data)
        {
            // TODO : Implement SortStringsByLengthAndAlphabet
            if (data.Count() == 0)
            {
                return Enumerable.Empty<string>();
            }

            var listData = data.ToList();

            listData.Sort();

            var result = listData.OrderBy(x => x.Length);

            return result;
        }

        /// <summary> Finds all missing digits </summary>
        /// <param name="data">the source data</param>
        /// <returns>
        /// Return all digits that are not in the string sequence
        /// </returns>
        /// <example>
        ///   {} => {'0','1','2','3','4','5','6','7','8','9'}
        ///   {"aaa","a1","b","c2","d","e3","f01234"} => {'5','6','7','8','9'}
        ///   {"a","b","c","9876543210"} => {}
        /// </example>
        public IEnumerable<char> GetMissingDigits(IEnumerable<string> data)
        {
            // TODO : Implement GetMissingDigits
            var numbersArray = "0123456789".ToCharArray();

            var result = numbersArray.Except(data.SelectMany(n => n.Where(char.IsDigit)));

            return result;

        }


        /// <summary> Sorts digit names </summary>
        /// <param name="data">the source data</param>
        /// <returns>
        /// Return all digit names sorted by numeric order
        /// </returns>
        /// <example>
        ///   {} => {}
        ///   {"nine","one"} => {"one","nine"}
        ///   {"one","two","three"} => {"one","two","three"}
        ///   {"nine","eight","nine","eight"} => {"eight","eight","nine","nine"}
        ///   {"one","one","one","zero"} => {"zero","one","one","one"}
        /// </example>
        public IEnumerable<string> SortDigitNamesByNumericOrder(IEnumerable<string> data)
        {
            // TODO : Implement SortDigitNamesByNumericOrder
            if (data.Count() == 0)
            {
                return Enumerable.Empty<string>();
            }

            var listData = data.ToList();

            List<string> listSort = TransformToNumber(listData);

            return listSort;
        }

        private static List<string> TransformToNumber(List<string> listData)
        {
            List<string> listDataToNumber = new List<string>();
            List<string> listSort = new List<string>();

            foreach (var item in listData)
            {
                switch (item.ToString())
                {
                    case "one":
                        listDataToNumber.Add("1");
                        break;
                    case "two":
                        listDataToNumber.Add("2");
                        break;
                    case "three":
                        listDataToNumber.Add("3");
                        break;
                    case "four":
                        listDataToNumber.Add("4");
                        break;
                    case "five":
                        listDataToNumber.Add("5");
                        break;
                    case "six":
                        listDataToNumber.Add("6");
                        break;
                    case "seven":
                        listDataToNumber.Add("7");
                        break;
                    case "eight":
                        listDataToNumber.Add("8");
                        break;
                    case "nine":
                        listDataToNumber.Add("9");
                        break;
                    default:
                        listDataToNumber.Add("0");
                        break;
                }
            }

            listDataToNumber.Sort();

            foreach (var item in listDataToNumber)
            {
                switch (item.ToString())
                {
                    case "1":
                        listSort.Add("one");
                        break;
                    case "2":
                        listSort.Add("two");
                        break;
                    case "3":
                        listSort.Add("three");
                        break;
                    case "4":
                        listSort.Add("four");
                        break;
                    case "5":
                        listSort.Add("five");
                        break;
                    case "6":
                        listSort.Add("six");
                        break;
                    case "7":
                        listSort.Add("seven");
                        break;
                    case "8":
                        listSort.Add("eight");
                        break;
                    case "9":
                        listSort.Add("nine");
                        break;
                    default:
                        listSort.Add("zero");
                        break;
                }
            }

            return listSort;
        }

        /// <summary> Combines numbers and fruits </summary>
        /// <param name="numbers">string sequience of numbers</param>
        /// <param name="fruits">string sequence of fruits</param>
        /// <returns>
        ///   Returns new sequence of merged number and fruit items
        /// </returns>
        /// <example>
        ///  {"one","two","three"}, {"apple", "bananas","pineapples"} => {"one apple","two bananas","three pineapples"}
        ///  {"one"}, {"apple", "bananas","pineapples"} => {"one apple"}
        ///  {"one","two","three"}, {"apple", "bananas" } => {"one apple","two bananas"}
        ///  {"one","two","three"}, { } => { }
        ///  { }, {"apple", "bananas" } => { }
        /// </example>
        public IEnumerable<string> CombineNumbersAndFruits(IEnumerable<string> numbers, IEnumerable<string> fruits)
        {
            // TODO : Implement CombinesNumbersAndFruits
            if (numbers.Count() == 0 || fruits.Count() == 0)
            {
                return Enumerable.Empty<string>();
            }

            var listNumbers = numbers.ToList();
            var listFruits = fruits.ToList();

            List<string> list = new List<string>();

            for (int i = 0; i < listNumbers.Count() && i < listFruits.Count(); i++)
            {
                list.Add(listNumbers[i] + " " + listFruits[i]);

            }

            return list;
        }


        /// <summary> Finds all chars that are common for all words </summary>
        /// <param name="data">sequence of words</param>
        /// <returns>
        ///  Returns set of chars that are occured in all words (sorted in alphabetical order)
        /// </returns>
        /// <example>
        ///   {"ab","ac","ad"} => {"a"}
        ///   {"a","b","c"} => { }
        ///   {"a","aa","aaa"} => {"a"}
        ///   {"ab","ba","aabb","baba"} => {"a","b"}
        /// </example>
        public IEnumerable<char> GetCommonChars(IEnumerable<string> data)
        {
            // TODO : Implement GetCommonChars
            if (data.Count() == 0)
            {
                return string.Empty;
            }

            var result = data.DefaultIfEmpty(Enumerable.Empty<char>()).Aggregate((x, y) => x.Intersect(y));

            return result;
        }

        /// <summary> Calculates sum of all integers from object array </summary>
        /// <param name="data">source data</param>
        /// <returns>
        ///    Returns the sum of all inetegers from object array
        /// </returns>
        /// <example>
        ///    { 1, true, "a","b", false, 1 } => 2
        ///    { true, false } => 0
        ///    { 10, "ten", 10 } => 20 
        ///    { } => 0
        /// </example>
        public int GetSumOfAllInts(object[] data)
        {
            // TODO : Implement GetSumOfAllInts
            if (data.Length == 0)
            {
                return 0;
            }

            var result = data.OfType<int>();

            return result.Count() == 0 ? 0 : result.Sum();
        }


        /// <summary> Finds all strings in array of objects</summary>
        /// <param name="data">source array</param>
        /// <returns>
        ///   Return subsequence of string from source array of objects
        /// </returns>
        /// <example>
        ///   { "a", 1, 2, null, "b", true, 4.5, "c" } => { "a", "b", "c" }
        ///   { "a", "b", "c" } => { "a", "b", "c" }
        ///   { 1,2,3, true, false } => { }
        ///   { } => { }
        /// </example>
        public IEnumerable<string> GetStringsOnly(object[] data)
        {
            // TODO : Implement GetStringsOnly
            if (data.Length == 0)
            {
                return Enumerable.Empty<string>();
            }

            var result = data.OfType<string>();

            return result;
        }

        /// <summary> Calculates the total length of strings</summary>
        /// <param name="data">source string sequence</param>
        /// <returns>
        ///   Return sum of length of all strings
        /// </returns>
        /// <example>
        ///   {"a","b","c","d","e","f"} => 6
        ///   { "a","aa","aaa" } => 6
        ///   { "1234567890" } => 10
        ///   { null, "", "a" } => 1
        ///   { null } => 0
        ///   { } => 0
        /// </example>
        public int GetTotalStringsLength(IEnumerable<string> data)
        {
            // TODO : Implement GetTotalStringsLength
            var listData = data.ToList();

            var result = listData.Where(x => !string.IsNullOrEmpty(x));

            string result1 = string.Empty;

            foreach (var item in result)
            {
                result1 += item;
            }

            return result1.Length;
        }

        /// <summary> Determines whether sequence has null elements</summary>
        /// <param name="data">source string sequence</param>
        /// <returns>
        ///  true if the source sequence contains null elements; otherwise, false.
        /// </returns>
        /// <example>
        ///   { "a", "b", "c", "d", "e", "f" } => false
        ///   { "a", "aa", "aaa", null } => true
        ///   { "" } => false
        ///   { null, null, null } => true
        ///   { } => false
        /// </example>
        public bool IsSequenceHasNulls(IEnumerable<string> data)
        {
            // TODO : Implement IsSequenceHasNulls
            var listData = data.ToList();

            var result = listData.Where(x => x is null);

            return result.Count() > 0 ? true : false;
        }

        /// <summary> Determines whether all strings in sequence are uppercase</summary>
        /// <param name="data">source string sequence</param>
        /// <returns>
        ///  true if all strings from source sequence are uppercase; otherwise, false.
        /// </returns>
        /// <example>
        ///   { "A", "B", "C", "D", "E", "F" } => true
        ///   { "AA", "AA", "AAA", "AAAa" } => false
        ///   { "" } => false
        ///   { } => false
        /// </example>
        public bool IsAllStringsAreUppercase(IEnumerable<string> data)
        {
            // TODO : Implement IsAllStringsAreUppercase
            if (data.Count() <= 1)
            {
                return false;
            }

            var listData = data.ToList();

            var result = listData.Where(x => string.Equals(x, x.ToUpper()));

            return listData.SequenceEqual(result);
        }

        /// <summary> Finds first subsequence of negative integers </summary>
        /// <param name="data">source integer sequence</param>
        /// <returns>
        ///   Returns the first subsequence of negative integers from source
        /// </returns>
        /// <example>
        ///    { -2, -1 , 0, 1, 2 } => { -2, -1 }
        ///    { 2, 1, 0, -1, -2 } => { -1, -2 }
        ///    { 1, 1, 1, -1, -1, -1, 0, 0, 0, -2, -2, -2 } => { -1, -1, -1 }
        ///    { -1 , 0, -2 } => { -1 }
        ///    { 1, 2, 3 } => { }
        ///    { } => { }
        /// </example>
        public IEnumerable<int> GetFirstNegativeSubsequence(IEnumerable<int> data)
        {
            // TODO : Implement GetFirstNegativeSubsequence

            var result = data.SkipWhile(x => x >= 0).TakeWhile(x => x < 0);

            return result;
        }


        /// <summary> 
        /// Compares two numeric sequences
        /// </summary>
        /// <param name="integers">sequence of integers</param>
        /// <param name="doubles">sequence of doubles</param>
        /// <returns>
        /// true if integers are equals doubles; otherwise, false.
        /// </returns>
        /// <example>
        /// { 1,2,3 } , { 1.0, 2.0, 3.0 } => true
        /// { 0,0,0 } , { 1.0, 2.0, 3.0 } => false
        /// { 3,2,1 } , { 1.0, 2.0, 3.0 } => false
        /// { -10 } => { -10.0 } => true
        /// </example>
        public bool AreNumericListsEqual(IEnumerable<int> integers, IEnumerable<double> doubles)
        {
            // TODO : Implement AreNumericListsEqual
            var listIntegers = integers.ToList();
            var listDouble = doubles.ToList();

            var list = listIntegers.Select(x => (double)x);

            bool result = list.SequenceEqual(listDouble);

            return result;
        }

        /// <summary>
        /// Finds the next after specified version from the list 
        /// </summary>
        /// <param name="versions">source list of versions</param>
        /// <param name="currentVersion">specified version</param>
        /// <returns>
        ///   Returns the next after specified version from the list; otherwise, null.
        /// </returns>
        /// <example>
        ///    { "1.1", "1.2", "1.5", "2.0" }, "1.1" => "1.2"
        ///    { "1.1", "1.2", "1.5", "2.0" }, "1.2" => "1.5"
        ///    { "1.1", "1.2", "1.5", "2.0" }, "1.4" => null
        ///    { "1.1", "1.2", "1.5", "2.0" }, "2.0" => null
        /// </example>
        public string GetNextVersionFromList(IEnumerable<string> versions, string currentVersion)
        {
            // TODO : Implement GetNextVersionFromList
            var listVersions = versions.ToList();

            if (currentVersion == listVersions[listVersions.Count() - 1])
            {
                return null;
            }

            var result = listVersions.Select((x, y) =>
            {
                if (x == currentVersion)
                {
                    return listVersions[y + 1];
                }
                else
                {
                    return null;
                }
            })
                .Where(x => x != null);

            var result1 = result.Select(x => x).Where(x => x != null).ToList();


            return result1.Count() > 0 ? result1[0].ToString() : null;
        }

        /// <summary>
        ///  Calcuates the sum of two vectors:
        ///  (x1, x2, ..., xn) + (y1, y2, ..., yn) = (x1+y1, x2+y2, ..., xn+yn)
        /// </summary>
        /// <param name="vector1">source vector 1</param>
        /// <param name="vector2">source vector 2</param>
        /// <returns>
        ///  Returns the sum of two vectors
        /// </returns>
        /// <example>
        ///   { 1, 2, 3 } + { 10, 20, 30 } => { 11, 22, 33 }
        ///   { 1, 1, 1 } + { -1, -1, -1 } => { 0, 0, 0 }
        /// </example>
        public IEnumerable<int> GetSumOfVectors(IEnumerable<int> vector1, IEnumerable<int> vector2)
        {
            // TODO : Implement GetSumOfVectors
            var listVector1 = vector1.ToList();
            var listVector2 = vector2.ToList();

            var sumVector = listVector1.Zip(listVector2, (first, second) => first + second);

            return sumVector;
        }

        /// <summary>
        ///  Calcuates the product of two vectors:
        ///  (x1, x2, ..., xn) + (y1, y2, ..., yn) = x1*y1 + x2*y2 + ... + xn*yn
        /// </summary>
        /// <param name="vector1">source vector 1</param>
        /// <param name="vector2">source vector 2</param>
        /// <returns>
        ///  Returns the product of two vectors
        /// </returns>
        /// <example>
        ///   { 1, 2, 3 } * { 1, 2, 3 } => 1*1 + 2*2 + 3*3 = 14
        ///   { 1, 1, 1 } * { -1, -1, -1 } => 1*-1 + 1*-1 + 1*-1 = -3
        ///   { 1, 1, 1 } * { 0, 0, 0 } => 1*0 + 1*0 +1*0 = 0
        /// </example>
        public int GetProductOfVectors(IEnumerable<int> vector1, IEnumerable<int> vector2)
        {
            // TODO : Implement GetProductOfVectors
            var listVector1 = vector1.ToList();
            var listVector2 = vector2.ToList();

            var multipleVector = listVector1.Zip(listVector2, (first, second) => first * second);

            return multipleVector.Sum();
        }


        /// <summary>
        ///   Finds all boy+girl pair
        /// </summary>
        /// <param name="boys">boys' names</param>
        /// <param name="girls">girls' names</param>
        /// <returns>
        ///   Returns all combination of boys and girls names 
        /// </returns>
        /// <example>
        ///  {"John", "Josh", "Jacob" }, {"Ann", "Alice"} => {"John+Ann","John+Alice", "Josh+Ann","Josh+Alice", "Jacob+Ann", "Jacob+Alice" }
        ///  {"John"}, {"Alice"} => {"John+Alice"}
        ///  {"John"}, { } => { }
        ///  { }, {"Alice"} => { }
        /// </example>
        public IEnumerable<string> GetAllPairs(IEnumerable<string> boys, IEnumerable<string> girls)
        {
            // TODO : Implement GetAllPairs


            var listBoys = boys.ToList();
            var listGirls = girls.ToList();

            if (listGirls.Count() == 0 || listBoys.Count() == 0)
            {
                return Enumerable.Empty<string>();
            }

            var pairs = from first in listBoys
                        from second in listGirls
                        select new[] { first + "+" + second };

            return pairs.SelectMany(o => o);
        }


        /// <summary>
        ///   Calculates the average of all double values from object collection
        /// </summary>
        /// <param name="data">the source sequence</param>
        /// <returns>
        ///  Returns the average of all double values
        /// </returns>
        /// <example>
        ///  { 1.0, 2.0, null, "a" } => 1.5
        ///  { "1.0", "2.0", "3.0" } => 0.0  (no double values, strings only)
        ///  { null, 1.0, true } => 1.0
        ///  { } => 0.0
        /// </example>
        public double GetAverageOfDoubleValues(IEnumerable<object> data)
        {
            // TODO : Implement GetAverageOfDoubleValues
            if (data.Count() == 0)
            {
                return 0.0;
            }

            var list = data.ToList();

            var temp = list.OfType<double>();

            if (temp.Count() == 0)
            {
                return 0.0;
            }

            double average = list.OfType<double>().Average();

            return average;
        }

    }
}
