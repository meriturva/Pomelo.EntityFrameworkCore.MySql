using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Pomelo.EntityFrameworkCore.MySql.FunctionalTests.TestUtilities;
using Xunit;
using Xunit.Abstractions;

namespace Pomelo.EntityFrameworkCore.MySql.FunctionalTests.Query
{
    public partial class NorthwindFunctionsQueryMySqlTest : NorthwindFunctionsQueryRelationalTestBase<
        CaseSensitiveNorthwindQueryMySqlFixture<NoopModelCustomizer>>
    {
        public NorthwindFunctionsQueryMySqlTest(
            CaseSensitiveNorthwindQueryMySqlFixture<NoopModelCustomizer> fixture,
            ITestOutputHelper testOutputHelper)
            : base(fixture)
        {
            ClearLog();
            //Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
        }

        [ConditionalTheory]
        public override async Task String_StartsWith_Literal(bool async)
        {
            await base.String_StartsWith_Literal(async);

            AssertSql(
"""
SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`ContactName` LIKE 'M%'
""");
        }

        [ConditionalTheory]
        public override async Task String_StartsWith_Identity(bool async)
        {
            await base.String_StartsWith_Identity(async);

            AssertSql(
"""
SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`ContactName` IS NOT NULL AND (LEFT(`c`.`ContactName`, CHAR_LENGTH(`c`.`ContactName`)) = `c`.`ContactName`)
""");
        }

        [ConditionalTheory]
        public override async Task String_StartsWith_Column(bool async)
        {
            await base.String_StartsWith_Column(async);

            AssertSql(
"""
SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`ContactName` IS NOT NULL AND (LEFT(`c`.`ContactName`, CHAR_LENGTH(`c`.`ContactName`)) = `c`.`ContactName`)
""");
        }

        [ConditionalTheory]
        public override async Task String_StartsWith_MethodCall(bool async)
        {
            await base.String_StartsWith_MethodCall(async);

            AssertSql(
"""
SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`ContactName` LIKE 'M%'
""");
        }

        [ConditionalTheory]
        public override async Task String_EndsWith_Literal(bool async)
        {
            await base.String_EndsWith_Literal(async);

            AssertSql(
"""
SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`ContactName` LIKE '%b'
""");
        }

        [ConditionalTheory]
        public override async Task String_EndsWith_Identity(bool async)
        {
            await base.String_EndsWith_Identity(async);

            AssertSql(
"""
SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`ContactName` IS NOT NULL AND (RIGHT(`c`.`ContactName`, CHAR_LENGTH(`c`.`ContactName`)) = `c`.`ContactName`)
""");
        }

        [ConditionalTheory]
        public override async Task String_EndsWith_Column(bool async)
        {
            await base.String_EndsWith_Column(async);

            AssertSql(
"""
SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`ContactName` IS NOT NULL AND (RIGHT(`c`.`ContactName`, CHAR_LENGTH(`c`.`ContactName`)) = `c`.`ContactName`)
""");
        }

        [ConditionalTheory]
        public override async Task String_EndsWith_MethodCall(bool async)
        {
            await base.String_EndsWith_MethodCall(async);

            AssertSql(
"""
SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`ContactName` LIKE '%m'
""");
        }

        [ConditionalTheory]
        public override async Task String_Contains_Literal(bool async)
        {
            await base.String_Contains_Literal(async);

            AssertSql(
                @"SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`ContactName` LIKE '%M%'");
        }

        [ConditionalTheory]
        public override async Task String_Contains_Identity(bool async)
        {
            await base.String_Contains_Identity(async);

            AssertSql(
"""
SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`ContactName` IS NOT NULL AND ((LOCATE(`c`.`ContactName`, `c`.`ContactName`) > 0) OR (`c`.`ContactName` LIKE ''))
""");
        }

        [ConditionalTheory]
        public override async Task String_Contains_Column(bool async)
        {
            await base.String_Contains_Column(async);

        AssertSql(
"""
SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`ContactName` IS NOT NULL AND ((LOCATE(`c`.`ContactName`, `c`.`CompanyName`) > 0) OR (`c`.`ContactName` LIKE ''))
""");
        }

        [ConditionalTheory]
        public override async Task String_Contains_MethodCall(bool async)
        {
            await base.String_Contains_MethodCall(async);

            AssertSql(
                @"SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`ContactName` LIKE '%M%'");
        }

        [ConditionalTheory]
        public override async Task IsNullOrWhiteSpace_in_predicate(bool async)
        {
            await base.IsNullOrWhiteSpace_in_predicate(async);

            AssertSql(
                @"SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`Region` IS NULL OR (TRIM(`c`.`Region`) = '')");
        }

        [ConditionalTheory]
        public override async Task Indexof_with_emptystring(bool async)
        {
            await base.Indexof_with_emptystring(async);

        AssertSql(
"""
SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE (LOCATE('', `c`.`Region`) - 1) = 0
""");
        }

        [ConditionalTheory]
        public override async Task Replace_with_emptystring(bool async)
        {
            await base.Replace_with_emptystring(async);

            AssertSql(
                @"SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE REPLACE(`c`.`ContactName`, 'ia', '') = 'Mar Anders'");
        }

        [ConditionalTheory]
        public override async Task Substring_with_one_arg_with_zero_startindex(bool async)
        {
            await base.Substring_with_one_arg_with_zero_startindex(async);

            AssertSql(
                @"SELECT `c`.`ContactName`
FROM `Customers` AS `c`
WHERE SUBSTRING(`c`.`CustomerID`, 0 + 1, CHAR_LENGTH(`c`.`CustomerID`)) = 'ALFKI'");
        }

        [ConditionalTheory]
        public override async Task Substring_with_one_arg_with_constant(bool async)
        {
            await base.Substring_with_one_arg_with_constant(async);

            AssertSql(
                @"SELECT `c`.`ContactName`
FROM `Customers` AS `c`
WHERE SUBSTRING(`c`.`CustomerID`, 1 + 1, CHAR_LENGTH(`c`.`CustomerID`)) = 'LFKI'");
        }

        [ConditionalTheory]
        public override async Task Substring_with_one_arg_with_closure(bool async)
        {
            await base.Substring_with_one_arg_with_closure(async);

            AssertSql(
                @"@__start_0='2'

SELECT `c`.`ContactName`
FROM `Customers` AS `c`
WHERE SUBSTRING(`c`.`CustomerID`, @__start_0 + 1, CHAR_LENGTH(`c`.`CustomerID`)) = 'FKI'");
        }

        [ConditionalTheory]
        public override async Task Substring_with_two_args_with_zero_startindex(bool async)
        {
            await base.Substring_with_two_args_with_zero_startindex(async);

            AssertSql(
                @"SELECT SUBSTRING(`c`.`ContactName`, 0 + 1, 3)
FROM `Customers` AS `c`
WHERE `c`.`CustomerID` = 'ALFKI'");
        }

        [ConditionalTheory]
        public override async Task Substring_with_two_args_with_zero_length(bool async)
        {
            await base.Substring_with_two_args_with_zero_length(async);

            AssertSql(
                @"SELECT SUBSTRING(`c`.`ContactName`, 2 + 1, 0)
FROM `Customers` AS `c`
WHERE `c`.`CustomerID` = 'ALFKI'");
        }

        [ConditionalTheory]
        public override async Task Substring_with_two_args_with_constant(bool async)
        {
            await base.Substring_with_two_args_with_constant(async);

            AssertSql(
                @"SELECT SUBSTRING(`c`.`ContactName`, 1 + 1, 3)
FROM `Customers` AS `c`
WHERE `c`.`CustomerID` = 'ALFKI'");
        }

        [ConditionalTheory]
        public override async Task Substring_with_two_args_with_closure(bool async)
        {
            await base.Substring_with_two_args_with_closure(async);

            AssertSql(
                @"@__start_0='2'

SELECT SUBSTRING(`c`.`ContactName`, @__start_0 + 1, 3)
FROM `Customers` AS `c`
WHERE `c`.`CustomerID` = 'ALFKI'");
        }

        [ConditionalTheory]
        public override async Task Substring_with_two_args_with_Index_of(bool async)
        {
            await base.Substring_with_two_args_with_Index_of(async);

            AssertSql(
                @"SELECT SUBSTRING(`c`.`ContactName`, (LOCATE('a', `c`.`ContactName`) - 1) + 1, 3)
FROM `Customers` AS `c`
WHERE `c`.`CustomerID` = 'ALFKI'");
        }

        [ConditionalTheory]
        public override async Task Regex_IsMatch_MethodCall(bool async)
        {
            await base.Regex_IsMatch_MethodCall(async);

            AssertSql(
                @"SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`CustomerID` REGEXP '^T'");
        }

        [ConditionalTheory]
        public override async Task Regex_IsMatch_MethodCall_constant_input(bool async)
        {
            await base.Regex_IsMatch_MethodCall_constant_input(async);

            AssertSql(
                @"SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE 'ALFKI' REGEXP `c`.`CustomerID`");
        }

        [ConditionalTheory]
        public override async Task Where_math_abs1(bool async)
        {
            await base.Where_math_abs1(async);

            AssertSql(
                @"SELECT `p`.`ProductID`, `p`.`Discontinued`, `p`.`ProductName`, `p`.`SupplierID`, `p`.`UnitPrice`, `p`.`UnitsInStock`
FROM `Products` AS `p`
WHERE ABS(`p`.`ProductID`) > 10");
        }

        [ConditionalTheory]
        public override async Task Where_math_abs2(bool async)
        {
            await base.Where_math_abs2(async);

            AssertSql(
                @"SELECT `o`.`OrderID`, `o`.`ProductID`, `o`.`Discount`, `o`.`Quantity`, `o`.`UnitPrice`
FROM `Order Details` AS `o`
WHERE (`o`.`UnitPrice` < 7.0) AND (ABS(`o`.`Quantity`) > 10)");
        }

        [ConditionalTheory]
        public override async Task Where_math_abs_uncorrelated(bool async)
        {
            await base.Where_math_abs_uncorrelated(async);
            AssertSql(
"""
SELECT `o`.`OrderID`, `o`.`ProductID`, `o`.`Discount`, `o`.`Quantity`, `o`.`UnitPrice`
FROM `Order Details` AS `o`
WHERE (`o`.`UnitPrice` < 7.0) AND (10 < `o`.`ProductID`)
""");
        }

        [ConditionalTheory]
        public override async Task Select_math_round_int(bool async)
        {
            await base.Select_math_round_int(async);

            AssertSql(
                $@"SELECT ROUND({MySqlTestHelpers.CastAsDouble("`o`.`OrderID`")}) AS `A`
FROM `Orders` AS `o`
WHERE `o`.`OrderID` < 10250");
        }

        [ConditionalTheory]
        public override async Task Where_math_min(bool async)
        {
            await base.Where_math_min(async);

            AssertSql(
                @"SELECT `o`.`OrderID`, `o`.`ProductID`, `o`.`Discount`, `o`.`Quantity`, `o`.`UnitPrice`
FROM `Order Details` AS `o`
WHERE (`o`.`OrderID` = 11077) AND (LEAST(`o`.`OrderID`, `o`.`ProductID`) = `o`.`ProductID`)");
        }

        [ConditionalTheory]
        public override async Task Where_math_max(bool async)
        {
            await base.Where_math_max(async);

            AssertSql(
                @"SELECT `o`.`OrderID`, `o`.`ProductID`, `o`.`Discount`, `o`.`Quantity`, `o`.`UnitPrice`
FROM `Order Details` AS `o`
WHERE (`o`.`OrderID` = 11077) AND (GREATEST(`o`.`OrderID`, `o`.`ProductID`) = `o`.`OrderID`)");
        }

        [ConditionalTheory]
        public override async Task Where_string_to_lower(bool async)
        {
            await base.Where_string_to_lower(async);

            AssertSql(
                @"SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE LOWER(`c`.`CustomerID`) = 'alfki'");
        }

        [ConditionalTheory]
        public override async Task Where_string_to_upper(bool async)
        {
            await base.Where_string_to_upper(async);

            AssertSql(
                @"SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE UPPER(`c`.`CustomerID`) = 'ALFKI'");
        }

        [ConditionalTheory]
        public override async Task TrimStart_without_arguments_in_predicate(bool async)
        {
            await base.TrimStart_without_arguments_in_predicate(async);

            AssertSql(
                @"SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE TRIM(LEADING FROM `c`.`ContactTitle`) = 'Owner'");
        }

        [ConditionalTheory]
        public override async Task TrimStart_with_char_argument_in_predicate(bool async)
        {
            await base.TrimStart_with_char_argument_in_predicate(async);

            AssertSql(
                @"SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE TRIM(LEADING 'O' FROM `c`.`ContactTitle`) = 'wner'");
        }

        [ConditionalTheory]
        public override Task TrimStart_with_char_array_argument_in_predicate(bool async)
        {
            // MySQL only supports a string (characters in fixed order) as the parameter specifying what should be trimmed.
            // String.TrimStart has a different behavior, where any single character in any order will be trimmed.
            // Therefore, calling String.TrimStart with more than one char to trim, triggers client eval.
            return Assert.ThrowsAsync<InvalidOperationException>(() => base.TrimStart_with_char_array_argument_in_predicate(async));
        }

        [ConditionalTheory]
        public override async Task TrimEnd_without_arguments_in_predicate(bool async)
        {
            await base.TrimEnd_without_arguments_in_predicate(async);

            AssertSql(
                @"SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE TRIM(TRAILING FROM `c`.`ContactTitle`) = 'Owner'");
        }

        [ConditionalTheory]
        public override async Task TrimEnd_with_char_argument_in_predicate(bool async)
        {
            await base.TrimEnd_with_char_argument_in_predicate(async);

            AssertSql(
                @"SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE TRIM(TRAILING 'r' FROM `c`.`ContactTitle`) = 'Owne'");
        }

        [ConditionalTheory]
        public override Task TrimEnd_with_char_array_argument_in_predicate(bool async)
        {
            // MySQL only supports a string (characters in fixed order) as the parameter specifying what should be trimmed.
            // String.TrimEnd has a different behavior, where any single character in any order will be trimmed.
            // Therefore, calling String.TrimEnd with more than one char to trim, triggers client eval.
            return Assert.ThrowsAsync<InvalidOperationException>(() => base.TrimEnd_with_char_array_argument_in_predicate(async));
        }

        [ConditionalTheory]
        public override async Task Trim_without_argument_in_predicate(bool async)
        {
            await base.Trim_without_argument_in_predicate(async);

            AssertSql(
                @"SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE TRIM(`c`.`ContactTitle`) = 'Owner'");
        }

        [ConditionalTheory]
        public override async Task Trim_with_char_argument_in_predicate(bool async)
        {
            await base.Trim_with_char_argument_in_predicate(async);

            AssertSql(
                @"SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE TRIM('O' FROM `c`.`ContactTitle`) = 'wner'");
        }

        [ConditionalTheory]
        public override Task Trim_with_char_array_argument_in_predicate(bool async)
        {
            // MySQL only supports a string (characters in fixed order) as the parameter specifying what should be trimmed.
            // String.Trim has a different behavior, where any single character in any order will be trimmed.
            // Therefore, calling String.Trim with more than one char to trim, triggers client eval.
            return Assert.ThrowsAsync<InvalidOperationException>(() => base.Trim_with_char_array_argument_in_predicate(async));
        }

        public override async Task String_FirstOrDefault_MethodCall(bool async)
        {
            await base.String_FirstOrDefault_MethodCall(async);

            AssertSql(
                @"SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE SUBSTRING(`c`.`ContactName`, 1, 1) = 'A'");
        }

        public override async Task String_Contains_constant_with_whitespace(bool async)
        {
            await base.String_Contains_constant_with_whitespace(async);

            AssertSql(
                @"SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`ContactName` LIKE '%     %'");
        }

        public override async Task String_Contains_parameter_with_whitespace(bool async)
        {
            await base.String_Contains_parameter_with_whitespace(async);

        AssertSql(
"""
@__pattern_0_contains='%     %' (Size = 30)

SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`ContactName` LIKE @__pattern_0_contains
""");
        }

        public override async Task String_LastOrDefault_MethodCall(bool async)
        {
            await base.String_LastOrDefault_MethodCall(async);

            AssertSql(
                @"SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE SUBSTRING(`c`.`ContactName`, CHAR_LENGTH(`c`.`ContactName`), 1) = 's'");
        }

        public override async Task Where_math_abs3(bool async)
        {
            await base.Where_math_abs3(async);

            AssertSql(
                @"SELECT `o`.`OrderID`, `o`.`ProductID`, `o`.`Discount`, `o`.`Quantity`, `o`.`UnitPrice`
FROM `Order Details` AS `o`
WHERE (`o`.`Quantity` < 5) AND (ABS(`o`.`UnitPrice`) > 10.0)");
        }

        public override async Task Where_math_ceiling1(bool async)
        {
            await base.Where_math_ceiling1(async);

            AssertSql(
                $@"SELECT `o`.`OrderID`, `o`.`ProductID`, `o`.`Discount`, `o`.`Quantity`, `o`.`UnitPrice`
FROM `Order Details` AS `o`
WHERE (`o`.`UnitPrice` < 7.0) AND (CEILING({MySqlTestHelpers.CastAsDouble("`o`.`Discount`")}) > 0.0)");
        }

        public override async Task Where_math_ceiling2(bool async)
        {
            await base.Where_math_ceiling2(async);

            AssertSql(
                @"SELECT `o`.`OrderID`, `o`.`ProductID`, `o`.`Discount`, `o`.`Quantity`, `o`.`UnitPrice`
FROM `Order Details` AS `o`
WHERE (`o`.`Quantity` < 5) AND (CEILING(`o`.`UnitPrice`) > 10.0)");
        }

        public override async Task Where_math_floor(bool async)
        {
            await base.Where_math_floor(async);

            AssertSql(
                @"SELECT `o`.`OrderID`, `o`.`ProductID`, `o`.`Discount`, `o`.`Quantity`, `o`.`UnitPrice`
FROM `Order Details` AS `o`
WHERE (`o`.`Quantity` < 5) AND (FLOOR(`o`.`UnitPrice`) > 10.0)");
        }

        public override async Task Where_math_power(bool async)
        {
            await base.Where_math_power(async);

            AssertSql(
                $@"SELECT `o`.`OrderID`, `o`.`ProductID`, `o`.`Discount`, `o`.`Quantity`, `o`.`UnitPrice`
FROM `Order Details` AS `o`
WHERE POWER({MySqlTestHelpers.CastAsDouble("`o`.`Discount`")}, 3.0) > 0.004999999888241291");
        }

        public override async Task Where_math_round(bool async)
        {
            await base.Where_math_round(async);

            AssertSql(
                @"SELECT `o`.`OrderID`, `o`.`ProductID`, `o`.`Discount`, `o`.`Quantity`, `o`.`UnitPrice`
FROM `Order Details` AS `o`
WHERE (`o`.`Quantity` < 5) AND (ROUND(`o`.`UnitPrice`) > 10.0)");
        }

        public override async Task Select_math_truncate_int(bool async)
        {
            await base.Select_math_truncate_int(async);

            AssertSql(
                $@"SELECT TRUNCATE({MySqlTestHelpers.CastAsDouble("`o`.`OrderID`")}, 0) AS `A`
FROM `Orders` AS `o`
WHERE `o`.`OrderID` < 10250");
        }

        public override async Task Where_math_round2(bool async)
        {
            await base.Where_math_round2(async);

            AssertSql(
                @"SELECT `o`.`OrderID`, `o`.`ProductID`, `o`.`Discount`, `o`.`Quantity`, `o`.`UnitPrice`
FROM `Order Details` AS `o`
WHERE ROUND(`o`.`UnitPrice`, 2) > 100.0");
        }

        public override async Task Where_math_truncate(bool async)
        {
            await base.Where_math_truncate(async);

            AssertSql(
                @"SELECT `o`.`OrderID`, `o`.`ProductID`, `o`.`Discount`, `o`.`Quantity`, `o`.`UnitPrice`
FROM `Order Details` AS `o`
WHERE (`o`.`Quantity` < 5) AND (TRUNCATE(`o`.`UnitPrice`, 0) > 10.0)");
        }

        public override async Task Where_math_exp(bool async)
        {
            await base.Where_math_exp(async);

            AssertSql(
                $@"SELECT `o`.`OrderID`, `o`.`ProductID`, `o`.`Discount`, `o`.`Quantity`, `o`.`UnitPrice`
FROM `Order Details` AS `o`
WHERE (`o`.`OrderID` = 11077) AND (EXP({MySqlTestHelpers.CastAsDouble("`o`.`Discount`")}) > 1.0)");
        }

        public override async Task Where_math_log10(bool async)
        {
            await base.Where_math_log10(async);

            AssertSql(
                $@"SELECT `o`.`OrderID`, `o`.`ProductID`, `o`.`Discount`, `o`.`Quantity`, `o`.`UnitPrice`
FROM `Order Details` AS `o`
WHERE ((`o`.`OrderID` = 11077) AND (`o`.`Discount` > 0)) AND (LOG10({MySqlTestHelpers.CastAsDouble("`o`.`Discount`")}) < 0.0)");
        }

        public override async Task Where_math_log(bool async)
        {
            await base.Where_math_log(async);

            AssertSql(
                $@"SELECT `o`.`OrderID`, `o`.`ProductID`, `o`.`Discount`, `o`.`Quantity`, `o`.`UnitPrice`
FROM `Order Details` AS `o`
WHERE ((`o`.`OrderID` = 11077) AND (`o`.`Discount` > 0)) AND (LOG({MySqlTestHelpers.CastAsDouble("`o`.`Discount`")}) < 0.0)");
        }

        public override async Task Where_math_log_new_base(bool async)
        {
            await base.Where_math_log_new_base(async);

            AssertSql(
                $@"SELECT `o`.`OrderID`, `o`.`ProductID`, `o`.`Discount`, `o`.`Quantity`, `o`.`UnitPrice`
FROM `Order Details` AS `o`
WHERE ((`o`.`OrderID` = 11077) AND (`o`.`Discount` > 0)) AND (LOG(7.0, {MySqlTestHelpers.CastAsDouble("`o`.`Discount`")}) < -1.0)");
        }

        public override async Task Where_math_sqrt(bool async)
        {
            await base.Where_math_sqrt(async);

            AssertSql(
                $@"SELECT `o`.`OrderID`, `o`.`ProductID`, `o`.`Discount`, `o`.`Quantity`, `o`.`UnitPrice`
FROM `Order Details` AS `o`
WHERE (`o`.`OrderID` = 11077) AND (SQRT({MySqlTestHelpers.CastAsDouble("`o`.`Discount`")}) > 0.0)");
        }

        public override async Task Where_math_acos(bool async)
        {
            await base.Where_math_acos(async);

            AssertSql(
                $@"SELECT `o`.`OrderID`, `o`.`ProductID`, `o`.`Discount`, `o`.`Quantity`, `o`.`UnitPrice`
FROM `Order Details` AS `o`
WHERE (`o`.`OrderID` = 11077) AND (ACOS({MySqlTestHelpers.CastAsDouble("`o`.`Discount`")}) > 1.0)");
        }

        public override async Task Where_math_asin(bool async)
        {
            await base.Where_math_asin(async);

            AssertSql(
                $@"SELECT `o`.`OrderID`, `o`.`ProductID`, `o`.`Discount`, `o`.`Quantity`, `o`.`UnitPrice`
FROM `Order Details` AS `o`
WHERE (`o`.`OrderID` = 11077) AND (ASIN({MySqlTestHelpers.CastAsDouble("`o`.`Discount`")}) > 0.0)");
        }

        public override async Task Where_math_atan(bool async)
        {
            await base.Where_math_atan(async);

            AssertSql(
                $@"SELECT `o`.`OrderID`, `o`.`ProductID`, `o`.`Discount`, `o`.`Quantity`, `o`.`UnitPrice`
FROM `Order Details` AS `o`
WHERE (`o`.`OrderID` = 11077) AND (ATAN({MySqlTestHelpers.CastAsDouble("`o`.`Discount`")}) > 0.0)");
        }

        public override async Task Where_math_atan2(bool async)
        {
            await base.Where_math_atan2(async);

            AssertSql(
                $@"SELECT `o`.`OrderID`, `o`.`ProductID`, `o`.`Discount`, `o`.`Quantity`, `o`.`UnitPrice`
FROM `Order Details` AS `o`
WHERE (`o`.`OrderID` = 11077) AND (ATAN2({MySqlTestHelpers.CastAsDouble("`o`.`Discount`")}, 1.0) > 0.0)");
        }

        public override async Task Where_math_cos(bool async)
        {
            await base.Where_math_cos(async);

            AssertSql(
                $@"SELECT `o`.`OrderID`, `o`.`ProductID`, `o`.`Discount`, `o`.`Quantity`, `o`.`UnitPrice`
FROM `Order Details` AS `o`
WHERE (`o`.`OrderID` = 11077) AND (COS({MySqlTestHelpers.CastAsDouble("`o`.`Discount`")}) > 0.0)");
        }

        public override async Task Where_math_sin(bool async)
        {
            await base.Where_math_sin(async);

            AssertSql(
                $@"SELECT `o`.`OrderID`, `o`.`ProductID`, `o`.`Discount`, `o`.`Quantity`, `o`.`UnitPrice`
FROM `Order Details` AS `o`
WHERE (`o`.`OrderID` = 11077) AND (SIN({MySqlTestHelpers.CastAsDouble("`o`.`Discount`")}) > 0.0)");
        }

        public override async Task Where_math_tan(bool async)
        {
            await base.Where_math_tan(async);

            AssertSql(
                $@"SELECT `o`.`OrderID`, `o`.`ProductID`, `o`.`Discount`, `o`.`Quantity`, `o`.`UnitPrice`
FROM `Order Details` AS `o`
WHERE (`o`.`OrderID` = 11077) AND (TAN({MySqlTestHelpers.CastAsDouble("`o`.`Discount`")}) > 0.0)");
        }

        public override async Task Where_math_sign(bool async)
        {
            await base.Where_math_sign(async);

            AssertSql(
                @"SELECT `o`.`OrderID`, `o`.`ProductID`, `o`.`Discount`, `o`.`Quantity`, `o`.`UnitPrice`
FROM `Order Details` AS `o`
WHERE (`o`.`OrderID` = 11077) AND (SIGN(`o`.`Discount`) > 0)");
        }

        public override async Task Where_guid_newguid(bool async)
        {
            await base.Where_guid_newguid(async);

            AssertSql(
                @"SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE UUID() <> '00000000-0000-0000-0000-000000000000'");
        }

        public override async Task Where_functions_nested(bool async)
        {
            await base.Where_functions_nested(async);

            AssertSql(
                $@"SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE POWER({MySqlTestHelpers.CastAsDouble("CHAR_LENGTH(`c`.`CustomerID`)")}, 2.0) = 25.0");
        }

        public override async Task IsNullOrEmpty_in_predicate(bool async)
        {
            await base.IsNullOrEmpty_in_predicate(async);

            AssertSql(
                @"SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`Region` IS NULL OR (`c`.`Region` = '')");
        }

        public override async Task IsNullOrEmpty_in_projection(bool async)
        {
            await base.IsNullOrEmpty_in_projection(async);
        }

        public override async Task IsNullOrEmpty_negated_in_projection(bool async)
        {
            await base.IsNullOrEmpty_negated_in_projection(async);
        }

        public override async Task IsNullOrWhiteSpace_in_predicate_on_non_nullable_column(bool async)
        {
            await base.IsNullOrWhiteSpace_in_predicate_on_non_nullable_column(async);

            AssertSql(
                @"SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE TRIM(`c`.`CustomerID`) = ''");
        }

        public override async Task Order_by_length_twice(bool async)
        {
            await base.Order_by_length_twice(async);

            AssertSql(
                @"SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
ORDER BY CHAR_LENGTH(`c`.`CustomerID`), `c`.`CustomerID`");
        }

        public override async Task Order_by_length_twice_followed_by_projection_of_naked_collection_navigation(bool async)
        {
            await base.Order_by_length_twice_followed_by_projection_of_naked_collection_navigation(async);

            AssertSql(
                @"SELECT `c`.`CustomerID`, `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Customers` AS `c`
LEFT JOIN `Orders` AS `o` ON `c`.`CustomerID` = `o`.`CustomerID`
ORDER BY CHAR_LENGTH(`c`.`CustomerID`), `c`.`CustomerID`");
        }

        public override async Task Static_string_equals_in_predicate(bool async)
        {
            await base.Static_string_equals_in_predicate(async);

            AssertSql(
                @"SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`CustomerID` = 'ANATR'");
        }

        public override async Task Static_equals_nullable_datetime_compared_to_non_nullable(bool async)
        {
            await base.Static_equals_nullable_datetime_compared_to_non_nullable(async);

            AssertSql(
                @"@__arg_0='1996-07-04T00:00:00.0000000' (DbType = DateTime)

SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE `o`.`OrderDate` = @__arg_0");
        }

        public override async Task Static_equals_int_compared_to_long(bool async)
        {
            await base.Static_equals_int_compared_to_long(async);

            AssertSql(
                @"SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE FALSE");
        }

        public override async Task Projecting_Math_Truncate_and_ordering_by_it_twice(bool async)
        {
            await base.Projecting_Math_Truncate_and_ordering_by_it_twice(async);

            AssertSql(
                $@"SELECT TRUNCATE({MySqlTestHelpers.CastAsDouble("`o`.`OrderID`")}, 0) AS `A`
FROM `Orders` AS `o`
WHERE `o`.`OrderID` < 10250
ORDER BY TRUNCATE({MySqlTestHelpers.CastAsDouble("`o`.`OrderID`")}, 0)");
        }

        public override async Task Projecting_Math_Truncate_and_ordering_by_it_twice2(bool async)
        {
            await base.Projecting_Math_Truncate_and_ordering_by_it_twice2(async);

            AssertSql(
                $@"SELECT TRUNCATE({MySqlTestHelpers.CastAsDouble("`o`.`OrderID`")}, 0) AS `A`
FROM `Orders` AS `o`
WHERE `o`.`OrderID` < 10250
ORDER BY TRUNCATE({MySqlTestHelpers.CastAsDouble("`o`.`OrderID`")}, 0) DESC");
        }

        public override async Task Projecting_Math_Truncate_and_ordering_by_it_twice3(bool async)
        {
            await base.Projecting_Math_Truncate_and_ordering_by_it_twice3(async);

            AssertSql(
                $@"SELECT TRUNCATE({MySqlTestHelpers.CastAsDouble("`o`.`OrderID`")}, 0) AS `A`
FROM `Orders` AS `o`
WHERE `o`.`OrderID` < 10250
ORDER BY TRUNCATE({MySqlTestHelpers.CastAsDouble("`o`.`OrderID`")}, 0) DESC");
        }

        public override async Task String_Compare_simple_zero(bool async)
        {
            await base.String_Compare_simple_zero(async);

            AssertSql(
"""
SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`CustomerID` = 'AROUT'
""",
                //
"""
SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`CustomerID` <> 'AROUT'
""",
                //
"""
SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`CustomerID` > 'AROUT'
""",
                //
"""
SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`CustomerID` <= 'AROUT'
""",
                //
"""
SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`CustomerID` > 'AROUT'
""",
                //
"""
SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`CustomerID` <= 'AROUT'
""");
        }

        public override async Task String_Compare_simple_one(bool async)
        {
            await base.String_Compare_simple_one(async);

            AssertSql(
"""
SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`CustomerID` > 'AROUT'
""",
                //
"""
SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`CustomerID` < 'AROUT'
""",
                //
"""
SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`CustomerID` <= 'AROUT'
""",
                //
"""
SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`CustomerID` <= 'AROUT'
""",
                //
"""
SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`CustomerID` >= 'AROUT'
""",
                //
"""
SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`CustomerID` >= 'AROUT'
""");
        }

        public override async Task String_compare_with_parameter(bool async)
        {
            await base.String_compare_with_parameter(async);

            AssertSql(
"""
@__customer_CustomerID_0='AROUT' (Size = 5) (DbType = StringFixedLength)

SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`CustomerID` > @__customer_CustomerID_0
""",
                //
"""
@__customer_CustomerID_0='AROUT' (Size = 5) (DbType = StringFixedLength)

SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`CustomerID` < @__customer_CustomerID_0
""",
                //
"""
@__customer_CustomerID_0='AROUT' (Size = 5) (DbType = StringFixedLength)

SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`CustomerID` <= @__customer_CustomerID_0
""",
                //
"""
@__customer_CustomerID_0='AROUT' (Size = 5) (DbType = StringFixedLength)

SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`CustomerID` <= @__customer_CustomerID_0
""",
                //
"""
@__customer_CustomerID_0='AROUT' (Size = 5) (DbType = StringFixedLength)

SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`CustomerID` >= @__customer_CustomerID_0
""",
                //
"""
@__customer_CustomerID_0='AROUT' (Size = 5) (DbType = StringFixedLength)

SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`CustomerID` >= @__customer_CustomerID_0
""");
        }

        public override async Task String_Compare_simple_more_than_one(bool async)
        {
            await base.String_Compare_simple_more_than_one(async);

            AssertSql(
                @"SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE CASE
    WHEN `c`.`CustomerID` = 'ALFKI' THEN 0
    WHEN `c`.`CustomerID` > 'ALFKI' THEN 1
    WHEN `c`.`CustomerID` < 'ALFKI' THEN -1
END = 42",
                //
                @"SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE CASE
    WHEN `c`.`CustomerID` = 'ALFKI' THEN 0
    WHEN `c`.`CustomerID` > 'ALFKI' THEN 1
    WHEN `c`.`CustomerID` < 'ALFKI' THEN -1
END > 42",
                //
                @"SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE 42 > CASE
    WHEN `c`.`CustomerID` = 'ALFKI' THEN 0
    WHEN `c`.`CustomerID` > 'ALFKI' THEN 1
    WHEN `c`.`CustomerID` < 'ALFKI' THEN -1
END");
        }

        public override async Task String_Compare_nested(bool async)
        {
            await base.String_Compare_nested(async);

            AssertSql(
                @"SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`CustomerID` = (CONCAT('M', `c`.`CustomerID`))",
                //
                @"SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`CustomerID` <> UPPER(`c`.`CustomerID`)",
                //
                @"SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`CustomerID` > REPLACE('ALFKI', 'ALF', `c`.`CustomerID`)",
                //
                @"SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`CustomerID` <= (CONCAT('M', `c`.`CustomerID`))",
                //
                @"SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`CustomerID` > UPPER(`c`.`CustomerID`)",
                //
                @"SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`CustomerID` < REPLACE('ALFKI', 'ALF', `c`.`CustomerID`)");
        }

        public override async Task String_Compare_multi_predicate(bool async)
        {
            await base.String_Compare_multi_predicate(async);

            AssertSql(
                @"SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE (`c`.`CustomerID` >= 'ALFKI') AND (`c`.`CustomerID` < 'CACTU')",
                //
                @"SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE (`c`.`ContactTitle` = 'Owner') AND ((`c`.`Country` <> 'USA') OR `c`.`Country` IS NULL)");
        }

        public override async Task String_Compare_to_simple_zero(bool async)
        {
            await base.String_Compare_to_simple_zero(async);

            AssertSql(
"""
SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`CustomerID` = 'AROUT'
""",
                //
"""
SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`CustomerID` <> 'AROUT'
""",
                //
"""
SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`CustomerID` > 'AROUT'
""",
                //
"""
SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`CustomerID` <= 'AROUT'
""",
                //
"""
SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`CustomerID` > 'AROUT'
""",
                //
"""
SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`CustomerID` <= 'AROUT'
""");
        }

        public override async Task String_Compare_to_simple_one(bool async)
        {
            await base.String_Compare_to_simple_one(async);

            AssertSql(
"""
SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`CustomerID` > 'AROUT'
""",
                //
"""
SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`CustomerID` < 'AROUT'
""",
                //
"""
SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`CustomerID` <= 'AROUT'
""",
                //
"""
SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`CustomerID` <= 'AROUT'
""",
                //
"""
SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`CustomerID` >= 'AROUT'
""",
                //
"""
SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`CustomerID` >= 'AROUT'
""");
        }

        public override async Task String_compare_to_with_parameter(bool async)
        {
            await base.String_compare_to_with_parameter(async);

            AssertSql(
"""
@__customer_CustomerID_0='AROUT' (Size = 5) (DbType = StringFixedLength)

SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`CustomerID` > @__customer_CustomerID_0
""",
                //
"""
@__customer_CustomerID_0='AROUT' (Size = 5) (DbType = StringFixedLength)

SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`CustomerID` < @__customer_CustomerID_0
""",
                //
"""
@__customer_CustomerID_0='AROUT' (Size = 5) (DbType = StringFixedLength)

SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`CustomerID` <= @__customer_CustomerID_0
""",
                //
"""
@__customer_CustomerID_0='AROUT' (Size = 5) (DbType = StringFixedLength)

SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`CustomerID` <= @__customer_CustomerID_0
""",
                //
"""
@__customer_CustomerID_0='AROUT' (Size = 5) (DbType = StringFixedLength)

SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`CustomerID` >= @__customer_CustomerID_0
""",
                //
"""
@__customer_CustomerID_0='AROUT' (Size = 5) (DbType = StringFixedLength)

SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`CustomerID` >= @__customer_CustomerID_0
""");
        }

        public override async Task String_Compare_to_simple_more_than_one(bool async)
        {
            await base.String_Compare_to_simple_more_than_one(async);

            AssertSql(
                @"SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE CASE
    WHEN `c`.`CustomerID` = 'ALFKI' THEN 0
    WHEN `c`.`CustomerID` > 'ALFKI' THEN 1
    WHEN `c`.`CustomerID` < 'ALFKI' THEN -1
END = 42",
                //
                @"SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE CASE
    WHEN `c`.`CustomerID` = 'ALFKI' THEN 0
    WHEN `c`.`CustomerID` > 'ALFKI' THEN 1
    WHEN `c`.`CustomerID` < 'ALFKI' THEN -1
END > 42",
                //
                @"SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE 42 > CASE
    WHEN `c`.`CustomerID` = 'ALFKI' THEN 0
    WHEN `c`.`CustomerID` > 'ALFKI' THEN 1
    WHEN `c`.`CustomerID` < 'ALFKI' THEN -1
END");
        }

        public override async Task String_Compare_to_nested(bool async)
        {
            await base.String_Compare_to_nested(async);

            AssertSql(
"""
SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`CustomerID` <> (CONCAT('M', `c`.`CustomerID`))
""",
                //
"""
SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`CustomerID` = UPPER(`c`.`CustomerID`)
""",
                //
"""
SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`CustomerID` > REPLACE('AROUT', 'OUT', `c`.`CustomerID`)
""",
                //
"""
SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`CustomerID` <= (CONCAT('M', `c`.`CustomerID`))
""",
                //
"""
SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`CustomerID` > UPPER(`c`.`CustomerID`)
""",
                //
"""
SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`CustomerID` < REPLACE('AROUT', 'OUT', `c`.`CustomerID`)
""");
        }

        public override async Task String_Compare_to_multi_predicate(bool async)
        {
            await base.String_Compare_to_multi_predicate(async);

            AssertSql(
                @"SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE (`c`.`CustomerID` >= 'ALFKI') AND (`c`.`CustomerID` < 'CACTU')",
                //
                @"SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE (`c`.`ContactTitle` = 'Owner') AND ((`c`.`Country` <> 'USA') OR `c`.`Country` IS NULL)");
        }

        public override async Task DateTime_Compare_to_simple_zero(bool async, bool compareTo)
        {
            await base.DateTime_Compare_to_simple_zero(async, compareTo);

            AssertSql(
                @"@__myDatetime_0='1998-05-04T00:00:00.0000000' (DbType = DateTime)

SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE `o`.`OrderDate` = @__myDatetime_0",
                //
                @"@__myDatetime_0='1998-05-04T00:00:00.0000000' (DbType = DateTime)

SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`OrderDate` <> @__myDatetime_0) OR `o`.`OrderDate` IS NULL",
                //
                @"@__myDatetime_0='1998-05-04T00:00:00.0000000' (DbType = DateTime)

SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE `o`.`OrderDate` > @__myDatetime_0",
                //
                @"@__myDatetime_0='1998-05-04T00:00:00.0000000' (DbType = DateTime)

SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE `o`.`OrderDate` <= @__myDatetime_0",
                //
                @"@__myDatetime_0='1998-05-04T00:00:00.0000000' (DbType = DateTime)

SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE `o`.`OrderDate` > @__myDatetime_0",
                //
                @"@__myDatetime_0='1998-05-04T00:00:00.0000000' (DbType = DateTime)

SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE `o`.`OrderDate` <= @__myDatetime_0");
        }

        public override async Task TimeSpan_Compare_to_simple_zero(bool async, bool compareTo)
        {
            await base.TimeSpan_Compare_to_simple_zero(async, compareTo);

            AssertSql(
                @"@__myDatetime_0='1998-05-04T00:00:00.0000000' (DbType = DateTime)

SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE `o`.`OrderDate` = @__myDatetime_0",
                //
                @"@__myDatetime_0='1998-05-04T00:00:00.0000000' (DbType = DateTime)

SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`OrderDate` <> @__myDatetime_0) OR `o`.`OrderDate` IS NULL",
                //
                @"@__myDatetime_0='1998-05-04T00:00:00.0000000' (DbType = DateTime)

SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE `o`.`OrderDate` > @__myDatetime_0",
                //
                @"@__myDatetime_0='1998-05-04T00:00:00.0000000' (DbType = DateTime)

SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE `o`.`OrderDate` <= @__myDatetime_0",
                //
                @"@__myDatetime_0='1998-05-04T00:00:00.0000000' (DbType = DateTime)

SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE `o`.`OrderDate` > @__myDatetime_0",
                //
                @"@__myDatetime_0='1998-05-04T00:00:00.0000000' (DbType = DateTime)

SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE `o`.`OrderDate` <= @__myDatetime_0");
        }

        public override async Task Int_Compare_to_simple_zero(bool async)
        {
            await base.Int_Compare_to_simple_zero(async);

            AssertSql(
                @"@__orderId_0='10250'

SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE `o`.`OrderID` = @__orderId_0",
                //
                @"@__orderId_0='10250'

SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE `o`.`OrderID` <> @__orderId_0",
                //
                @"@__orderId_0='10250'

SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE `o`.`OrderID` > @__orderId_0",
                //
                @"@__orderId_0='10250'

SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE `o`.`OrderID` <= @__orderId_0",
                //
                @"@__orderId_0='10250'

SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE `o`.`OrderID` > @__orderId_0",
                //
                @"@__orderId_0='10250'

SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE `o`.`OrderID` <= @__orderId_0");
        }

        public override async Task Convert_ToBoolean(bool async)
        {
            await base.Convert_ToBoolean(async);

        AssertSql(
"""
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND CAST(`o`.`OrderID` % 3 AS signed)
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND CAST(CAST(`o`.`OrderID` % 3 AS unsigned) AS signed)
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND CAST(CAST(`o`.`OrderID` % 3 AS decimal(65,30)) AS signed)
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND CAST(CAST(`o`.`OrderID` % 3 AS double) AS signed)
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND CAST(CAST(`o`.`OrderID` % 3 AS double) AS signed)
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND CAST(`o`.`OrderID` % 3 AS signed)
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND CAST(`o`.`OrderID` % 3 AS signed)
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND CAST(`o`.`OrderID` % 3 AS signed)
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND CAST(`o`.`OrderID` % 3 AS signed)
""");
        }

        public override async Task Convert_ToByte(bool async)
        {
            await base.Convert_ToByte(async);

        AssertSql(
"""
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(CAST(`o`.`OrderID` % 1 AS signed) AS unsigned) >= 0)
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(`o`.`OrderID` % 1 AS unsigned) >= 0)
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(CAST(`o`.`OrderID` % 1 AS decimal(65,30)) AS unsigned) >= 0)
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(CAST(`o`.`OrderID` % 1 AS double) AS unsigned) >= 0)
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(CAST(`o`.`OrderID` % 1 AS double) AS unsigned) >= 0)
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(CAST(`o`.`OrderID` % 1 AS signed) AS unsigned) >= 0)
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(CAST(`o`.`OrderID` % 1 AS signed) AS unsigned) >= 0)
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(CAST(`o`.`OrderID` % 1 AS signed) AS unsigned) >= 0)
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(CAST(`o`.`OrderID` % 1 AS char) AS unsigned) >= 0)
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(CAST(`o`.`OrderID` % 1 AS char) AS unsigned) >= 0)
""");
        }

        public override async Task Convert_ToDecimal(bool async)
        {
            await base.Convert_ToDecimal(async);

        AssertSql(
"""
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(CAST(`o`.`OrderID` % 1 AS signed) AS decimal(65,30)) >= 0.0)
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(CAST(`o`.`OrderID` % 1 AS unsigned) AS decimal(65,30)) >= 0.0)
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(`o`.`OrderID` % 1 AS decimal(65,30)) >= 0.0)
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(CAST(`o`.`OrderID` % 1 AS double) AS decimal(65,30)) >= 0.0)
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(CAST(`o`.`OrderID` % 1 AS double) AS decimal(65,30)) >= 0.0)
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(CAST(`o`.`OrderID` % 1 AS signed) AS decimal(65,30)) >= 0.0)
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(CAST(`o`.`OrderID` % 1 AS signed) AS decimal(65,30)) >= 0.0)
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(CAST(`o`.`OrderID` % 1 AS signed) AS decimal(65,30)) >= 0.0)
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(CAST(`o`.`OrderID` % 1 AS char) AS decimal(65,30)) >= 0.0)
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(CAST(`o`.`OrderID` % 1 AS char) AS decimal(65,30)) >= 0.0)
""");
        }

        public override async Task Convert_ToDouble(bool async)
        {
            await base.Convert_ToDouble(async);

            AssertSql(
                $@"SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND ({MySqlTestHelpers.CastAsDouble("CAST(`o`.`OrderID` % 1 AS signed)")} >= 0.0)",
                //
                $@"SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND ({MySqlTestHelpers.CastAsDouble("CAST(`o`.`OrderID` % 1 AS unsigned)")} >= 0.0)",
                //
                $@"SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND ({MySqlTestHelpers.CastAsDouble("CAST(`o`.`OrderID` % 1 AS decimal(65,30))")} >= 0.0)",
                //
                $@"SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND ({MySqlTestHelpers.CastAsDouble("`o`.`OrderID` % 1")} >= 0.0)",
                //
                $@"SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND ({MySqlTestHelpers.CastAsDouble("`o`.`OrderID` % 1")} >= 0.0)",
                //
                $@"SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND ({MySqlTestHelpers.CastAsDouble("CAST(`o`.`OrderID` % 1 AS signed)")} >= 0.0)",
                //
                $@"SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND ({MySqlTestHelpers.CastAsDouble("CAST(`o`.`OrderID` % 1 AS signed)")} >= 0.0)",
                //
                $@"SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND ({MySqlTestHelpers.CastAsDouble("CAST(`o`.`OrderID` % 1 AS signed)")} >= 0.0)",
                //
                $@"SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND ({MySqlTestHelpers.CastAsDouble("CAST(`o`.`OrderID` % 1 AS char)")} >= 0.0)",
                //
                $@"SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND ({MySqlTestHelpers.CastAsDouble("CAST(`o`.`OrderID` % 1 AS char)")} >= 0.0)");
        }

        public override async Task Convert_ToInt16(bool async)
        {
            await base.Convert_ToInt16(async);

        AssertSql(
"""
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(`o`.`OrderID` % 1 AS signed) >= 0)
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(CAST(`o`.`OrderID` % 1 AS unsigned) AS signed) >= 0)
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(CAST(`o`.`OrderID` % 1 AS decimal(65,30)) AS signed) >= 0)
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(CAST(`o`.`OrderID` % 1 AS double) AS signed) >= 0)
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(CAST(`o`.`OrderID` % 1 AS double) AS signed) >= 0)
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(`o`.`OrderID` % 1 AS signed) >= 0)
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(`o`.`OrderID` % 1 AS signed) >= 0)
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(`o`.`OrderID` % 1 AS signed) >= 0)
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(CAST(`o`.`OrderID` % 1 AS char) AS signed) >= 0)
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(CAST(`o`.`OrderID` % 1 AS char) AS signed) >= 0)
""");
        }

        public override async Task Convert_ToInt32(bool async)
        {
            await base.Convert_ToInt32(async);

        AssertSql(
"""
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(`o`.`OrderID` % 1 AS signed) >= 0)
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(CAST(`o`.`OrderID` % 1 AS unsigned) AS signed) >= 0)
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(CAST(`o`.`OrderID` % 1 AS decimal(65,30)) AS signed) >= 0)
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(CAST(`o`.`OrderID` % 1 AS double) AS signed) >= 0)
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(CAST(`o`.`OrderID` % 1 AS double) AS signed) >= 0)
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(`o`.`OrderID` % 1 AS signed) >= 0)
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(`o`.`OrderID` % 1 AS signed) >= 0)
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(`o`.`OrderID` % 1 AS signed) >= 0)
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(CAST(`o`.`OrderID` % 1 AS char) AS signed) >= 0)
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(CAST(`o`.`OrderID` % 1 AS char) AS signed) >= 0)
""");
        }

        public override async Task Convert_ToInt64(bool async)
        {
            await base.Convert_ToInt64(async);

        AssertSql(
"""
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(`o`.`OrderID` % 1 AS signed) >= 0)
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(CAST(`o`.`OrderID` % 1 AS unsigned) AS signed) >= 0)
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(CAST(`o`.`OrderID` % 1 AS decimal(65,30)) AS signed) >= 0)
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(CAST(`o`.`OrderID` % 1 AS double) AS signed) >= 0)
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(CAST(`o`.`OrderID` % 1 AS double) AS signed) >= 0)
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(`o`.`OrderID` % 1 AS signed) >= 0)
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(`o`.`OrderID` % 1 AS signed) >= 0)
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(`o`.`OrderID` % 1 AS signed) >= 0)
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(CAST(`o`.`OrderID` % 1 AS char) AS signed) >= 0)
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(CAST(`o`.`OrderID` % 1 AS char) AS signed) >= 0)
""");
        }

        public override async Task Convert_ToString(bool async)
        {
            await base.Convert_ToString(async);

        AssertSql(
"""
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(CAST(`o`.`OrderID` % 1 AS signed) AS char) <> '10')
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(CAST(`o`.`OrderID` % 1 AS unsigned) AS char) <> '10')
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(CAST(`o`.`OrderID` % 1 AS decimal(65,30)) AS char) <> '10')
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(CAST(`o`.`OrderID` % 1 AS double) AS char) <> '10')
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(CAST(`o`.`OrderID` % 1 AS double) AS char) <> '10')
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(CAST(`o`.`OrderID` % 1 AS signed) AS char) <> '10')
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(CAST(`o`.`OrderID` % 1 AS signed) AS char) <> '10')
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(CAST(`o`.`OrderID` % 1 AS signed) AS char) <> '10')
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(`o`.`OrderID` % 1 AS char) <> '10')
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND (CAST(`o`.`OrderID` % 1 AS char) <> '10')
""",
                //
                """
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (`o`.`CustomerID` = 'ALFKI') AND ((CAST(`o`.`OrderDate` AS char) LIKE '%1997%') OR (CAST(`o`.`OrderDate` AS char) LIKE '%1998%'))
""");
        }

        public override async Task String_StartsWith_Parameter(bool async)
        {
            await base.String_StartsWith_Parameter(async);

        AssertSql(
"""
@__pattern_0_startswith='M%' (Size = 30)

SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`ContactName` LIKE @__pattern_0_startswith
""");
        }

        public override async Task String_EndsWith_Parameter(bool async)
        {
            await base.String_EndsWith_Parameter(async);

        AssertSql(
"""
@__pattern_0_endswith='%b' (Size = 30)

SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`ContactName` LIKE @__pattern_0_endswith
""");
        }

        public override async Task String_Join_over_non_nullable_column(bool async)
        {
            await base.String_Join_over_non_nullable_column(async);

        AssertSql(
"""
SELECT `c1`.`City`, `c0`.`CustomerID`
FROM (
    SELECT `c`.`City`
    FROM `Customers` AS `c`
    GROUP BY `c`.`City`
) AS `c1`
LEFT JOIN `Customers` AS `c0` ON `c1`.`City` = `c0`.`City`
ORDER BY `c1`.`City`
""");
        }

        public override async Task String_Join_with_predicate(bool async)
        {
            await base.String_Join_with_predicate(async);

        AssertSql(
"""
SELECT `c1`.`City`, `c2`.`CustomerID`
FROM (
    SELECT `c`.`City`
    FROM `Customers` AS `c`
    GROUP BY `c`.`City`
) AS `c1`
LEFT JOIN (
    SELECT `c0`.`CustomerID`, `c0`.`City`
    FROM `Customers` AS `c0`
    WHERE CHAR_LENGTH(`c0`.`ContactName`) > 10
) AS `c2` ON `c1`.`City` = `c2`.`City`
ORDER BY `c1`.`City`
""");
        }

        public override async Task String_Join_with_ordering(bool async)
        {
            await base.String_Join_with_ordering(async);

        AssertSql(
"""
SELECT `c1`.`City`, `c0`.`CustomerID`
FROM (
    SELECT `c`.`City`
    FROM `Customers` AS `c`
    GROUP BY `c`.`City`
) AS `c1`
LEFT JOIN `Customers` AS `c0` ON `c1`.`City` = `c0`.`City`
ORDER BY `c1`.`City`, `c0`.`CustomerID` DESC
""");
        }

        public override async Task String_Join_over_nullable_column(bool async)
        {
            await base.String_Join_over_nullable_column(async);

        AssertSql(
"""
SELECT `c1`.`City`, `c0`.`Region`, `c0`.`CustomerID`
FROM (
    SELECT `c`.`City`
    FROM `Customers` AS `c`
    GROUP BY `c`.`City`
) AS `c1`
LEFT JOIN `Customers` AS `c0` ON `c1`.`City` = `c0`.`City`
ORDER BY `c1`.`City`
""");
        }

        public override async Task String_Concat(bool async)
        {
            await base.String_Concat(async);

        AssertSql(
"""
SELECT `c1`.`City`, `c0`.`CustomerID`
FROM (
    SELECT `c`.`City`
    FROM `Customers` AS `c`
    GROUP BY `c`.`City`
) AS `c1`
LEFT JOIN `Customers` AS `c0` ON `c1`.`City` = `c0`.`City`
ORDER BY `c1`.`City`
""");
        }

        public override async Task Where_math_square(bool async)
        {
            await base.Where_math_square(async);

            AssertSql(
$"""
SELECT `o`.`OrderID`, `o`.`ProductID`, `o`.`Discount`, `o`.`Quantity`, `o`.`UnitPrice`
FROM `Order Details` AS `o`
WHERE POWER({MySqlTestHelpers.CastAsDouble("`o`.`Discount`")}, 2.0) > 0.05000000074505806
""");
        }

        public override async Task Sum_over_round_works_correctly_in_projection(bool async)
        {
            await base.Sum_over_round_works_correctly_in_projection(async);

            AssertSql(
"""
SELECT `o`.`OrderID`, (
    SELECT COALESCE(SUM(ROUND(`o0`.`UnitPrice`, 2)), 0.0)
    FROM `Order Details` AS `o0`
    WHERE `o`.`OrderID` = `o0`.`OrderID`) AS `Sum`
FROM `Orders` AS `o`
WHERE `o`.`OrderID` < 10300
""");
        }

        public override async Task Sum_over_round_works_correctly_in_projection_2(bool async)
        {
            await base.Sum_over_round_works_correctly_in_projection_2(async);

            AssertSql(
"""
SELECT `o`.`OrderID`, (
    SELECT COALESCE(SUM(ROUND(`o0`.`UnitPrice` * `o0`.`UnitPrice`, 2)), 0.0)
    FROM `Order Details` AS `o0`
    WHERE `o`.`OrderID` = `o0`.`OrderID`) AS `Sum`
FROM `Orders` AS `o`
WHERE `o`.`OrderID` < 10300
""");
        }

        public override async Task Sum_over_truncate_works_correctly_in_projection(bool async)
        {
            await base.Sum_over_truncate_works_correctly_in_projection(async);

            AssertSql(
"""
SELECT `o`.`OrderID`, (
    SELECT COALESCE(SUM(TRUNCATE(`o0`.`UnitPrice`, 0)), 0.0)
    FROM `Order Details` AS `o0`
    WHERE `o`.`OrderID` = `o0`.`OrderID`) AS `Sum`
FROM `Orders` AS `o`
WHERE `o`.`OrderID` < 10300
""");
        }

        public override async Task Sum_over_truncate_works_correctly_in_projection_2(bool async)
        {
            await base.Sum_over_truncate_works_correctly_in_projection_2(async);

            AssertSql(
"""
SELECT `o`.`OrderID`, (
    SELECT COALESCE(SUM(TRUNCATE(`o0`.`UnitPrice` * `o0`.`UnitPrice`, 0)), 0.0)
    FROM `Order Details` AS `o0`
    WHERE `o`.`OrderID` = `o0`.`OrderID`) AS `Sum`
FROM `Orders` AS `o`
WHERE `o`.`OrderID` < 10300
""");
        }

        public override async Task Where_math_degrees(bool async)
        {
            await base.Where_math_degrees(async);

            AssertSql(
$"""
SELECT `o`.`OrderID`, `o`.`ProductID`, `o`.`Discount`, `o`.`Quantity`, `o`.`UnitPrice`
FROM `Order Details` AS `o`
WHERE (`o`.`OrderID` = 11077) AND (DEGREES({MySqlTestHelpers.CastAsDouble("`o`.`Discount`")}) > 0.0)
""");
        }

        public override async Task Where_math_radians(bool async)
        {
            await base.Where_math_radians(async);

            AssertSql(
$"""
SELECT `o`.`OrderID`, `o`.`ProductID`, `o`.`Discount`, `o`.`Quantity`, `o`.`UnitPrice`
FROM `Order Details` AS `o`
WHERE (`o`.`OrderID` = 11077) AND (RADIANS({MySqlTestHelpers.CastAsDouble("`o`.`Discount`")}) > 0.0)
""");
        }

        public override async Task Where_mathf_abs1(bool async)
        {
            await base.Where_mathf_abs1(async);

            AssertSql(
$"""
SELECT `p`.`ProductID`, `p`.`Discontinued`, `p`.`ProductName`, `p`.`SupplierID`, `p`.`UnitPrice`, `p`.`UnitsInStock`
FROM `Products` AS `p`
WHERE ABS({MySqlTestHelpers.CastAsDouble("`p`.`ProductID`")}) > 10
""");
        }

        public override async Task Where_mathf_ceiling1(bool async)
        {
            await base.Where_mathf_ceiling1(async);

            AssertSql(
"""
SELECT `o`.`OrderID`, `o`.`ProductID`, `o`.`Discount`, `o`.`Quantity`, `o`.`UnitPrice`
FROM `Order Details` AS `o`
WHERE (`o`.`UnitPrice` < 7.0) AND (CEILING(`o`.`Discount`) > 0)
""");
        }

        public override async Task Where_mathf_floor(bool async)
        {
            await base.Where_mathf_floor(async);

            AssertSql(
$"""
SELECT `o`.`OrderID`, `o`.`ProductID`, `o`.`Discount`, `o`.`Quantity`, `o`.`UnitPrice`
FROM `Order Details` AS `o`
WHERE (`o`.`Quantity` < 5) AND (FLOOR({MySqlTestHelpers.CastAsDouble("`o`.`UnitPrice`")}) > 10)
""");
        }

        public override async Task Where_mathf_power(bool async)
        {
            await base.Where_mathf_power(async);

            AssertSql(
"""
SELECT `o`.`OrderID`, `o`.`ProductID`, `o`.`Discount`, `o`.`Quantity`, `o`.`UnitPrice`
FROM `Order Details` AS `o`
WHERE POWER(`o`.`Discount`, 3) > 0.005
""");
        }

        public override async Task Where_mathf_square(bool async)
        {
            await base.Where_mathf_square(async);

            AssertSql(
"""
SELECT `o`.`OrderID`, `o`.`ProductID`, `o`.`Discount`, `o`.`Quantity`, `o`.`UnitPrice`
FROM `Order Details` AS `o`
WHERE POWER(`o`.`Discount`, 2) > 0.05
""");
        }

        public override async Task Where_mathf_round2(bool async)
        {
            await base.Where_mathf_round2(async);

            AssertSql(
$"""
SELECT `o`.`OrderID`, `o`.`ProductID`, `o`.`Discount`, `o`.`Quantity`, `o`.`UnitPrice`
FROM `Order Details` AS `o`
WHERE ROUND({MySqlTestHelpers.CastAsDouble("`o`.`UnitPrice`")}, 2) > 100
""");
        }

        public override async Task Select_mathf_round(bool async)
        {
            await base.Select_mathf_round(async);

            AssertSql(
$"""
SELECT ROUND({MySqlTestHelpers.CastAsDouble("`o`.`OrderID`")})
FROM `Orders` AS `o`
WHERE `o`.`OrderID` < 10250
""");
        }

        public override async Task Select_mathf_round2(bool async)
        {
            await base.Select_mathf_round2(async);

            AssertSql(
$"""
SELECT ROUND({MySqlTestHelpers.CastAsDouble("`o`.`UnitPrice`")}, 2)
FROM `Order Details` AS `o`
WHERE `o`.`Quantity` < 5
""");
        }

        public override async Task Where_mathf_truncate(bool async)
        {
            await base.Where_mathf_truncate(async);

            AssertSql(
$"""
SELECT `o`.`OrderID`, `o`.`ProductID`, `o`.`Discount`, `o`.`Quantity`, `o`.`UnitPrice`
FROM `Order Details` AS `o`
WHERE (`o`.`Quantity` < 5) AND (TRUNCATE({MySqlTestHelpers.CastAsDouble("`o`.`UnitPrice`")}, 0) > 10)
""");
        }

        public override async Task Select_mathf_truncate(bool async)
        {
            await base.Select_mathf_truncate(async);

            AssertSql(
$"""
SELECT TRUNCATE({MySqlTestHelpers.CastAsDouble("`o`.`UnitPrice`")}, 0)
FROM `Order Details` AS `o`
WHERE `o`.`Quantity` < 5
""");
        }

        public override async Task Where_mathf_exp(bool async)
        {
            await base.Where_mathf_exp(async);

            AssertSql(
"""
SELECT `o`.`OrderID`, `o`.`ProductID`, `o`.`Discount`, `o`.`Quantity`, `o`.`UnitPrice`
FROM `Order Details` AS `o`
WHERE (`o`.`OrderID` = 11077) AND (EXP(`o`.`Discount`) > 1)
""");
        }

        public override async Task Where_mathf_log10(bool async)
        {
            await base.Where_mathf_log10(async);

            AssertSql(
"""
SELECT `o`.`OrderID`, `o`.`ProductID`, `o`.`Discount`, `o`.`Quantity`, `o`.`UnitPrice`
FROM `Order Details` AS `o`
WHERE ((`o`.`OrderID` = 11077) AND (`o`.`Discount` > 0)) AND (LOG10(`o`.`Discount`) < 0)
""");
        }

        public override async Task Where_mathf_log(bool async)
        {
            await base.Where_mathf_log(async);

            AssertSql(
"""
SELECT `o`.`OrderID`, `o`.`ProductID`, `o`.`Discount`, `o`.`Quantity`, `o`.`UnitPrice`
FROM `Order Details` AS `o`
WHERE ((`o`.`OrderID` = 11077) AND (`o`.`Discount` > 0)) AND (LOG(`o`.`Discount`) < 0)
""");
        }

        public override async Task Where_mathf_log_new_base(bool async)
        {
            await base.Where_mathf_log_new_base(async);

        AssertSql(
"""
SELECT `o`.`OrderID`, `o`.`ProductID`, `o`.`Discount`, `o`.`Quantity`, `o`.`UnitPrice`
FROM `Order Details` AS `o`
WHERE ((`o`.`OrderID` = 11077) AND (`o`.`Discount` > 0)) AND (LOG(7, `o`.`Discount`) < -1)
""");
        }

        public override async Task Where_mathf_sqrt(bool async)
        {
            await base.Where_mathf_sqrt(async);

            AssertSql(
"""
SELECT `o`.`OrderID`, `o`.`ProductID`, `o`.`Discount`, `o`.`Quantity`, `o`.`UnitPrice`
FROM `Order Details` AS `o`
WHERE (`o`.`OrderID` = 11077) AND (SQRT(`o`.`Discount`) > 0)
""");
        }

        public override async Task Where_mathf_acos(bool async)
        {
            await base.Where_mathf_acos(async);

            AssertSql(
"""
SELECT `o`.`OrderID`, `o`.`ProductID`, `o`.`Discount`, `o`.`Quantity`, `o`.`UnitPrice`
FROM `Order Details` AS `o`
WHERE (`o`.`OrderID` = 11077) AND (ACOS(`o`.`Discount`) > 1)
""");
        }

        public override async Task Where_mathf_asin(bool async)
        {
            await base.Where_mathf_asin(async);

            AssertSql(
"""
SELECT `o`.`OrderID`, `o`.`ProductID`, `o`.`Discount`, `o`.`Quantity`, `o`.`UnitPrice`
FROM `Order Details` AS `o`
WHERE (`o`.`OrderID` = 11077) AND (ASIN(`o`.`Discount`) > 0)
""");
        }

        public override async Task Where_mathf_atan(bool async)
        {
            await base.Where_mathf_atan(async);

            AssertSql(
"""
SELECT `o`.`OrderID`, `o`.`ProductID`, `o`.`Discount`, `o`.`Quantity`, `o`.`UnitPrice`
FROM `Order Details` AS `o`
WHERE (`o`.`OrderID` = 11077) AND (ATAN(`o`.`Discount`) > 0)
""");
        }

        public override async Task Where_mathf_atan2(bool async)
        {
            await base.Where_mathf_atan2(async);

            AssertSql(
"""
SELECT `o`.`OrderID`, `o`.`ProductID`, `o`.`Discount`, `o`.`Quantity`, `o`.`UnitPrice`
FROM `Order Details` AS `o`
WHERE (`o`.`OrderID` = 11077) AND (ATAN2(`o`.`Discount`, 1) > 0)
""");
        }

        public override async Task Where_mathf_cos(bool async)
        {
            await base.Where_mathf_cos(async);

            AssertSql(
"""
SELECT `o`.`OrderID`, `o`.`ProductID`, `o`.`Discount`, `o`.`Quantity`, `o`.`UnitPrice`
FROM `Order Details` AS `o`
WHERE (`o`.`OrderID` = 11077) AND (COS(`o`.`Discount`) > 0)
""");
        }

        public override async Task Where_mathf_sin(bool async)
        {
            await base.Where_mathf_sin(async);

            AssertSql(
"""
SELECT `o`.`OrderID`, `o`.`ProductID`, `o`.`Discount`, `o`.`Quantity`, `o`.`UnitPrice`
FROM `Order Details` AS `o`
WHERE (`o`.`OrderID` = 11077) AND (SIN(`o`.`Discount`) > 0)
""");
        }

        public override async Task Where_mathf_tan(bool async)
        {
            await base.Where_mathf_tan(async);

            AssertSql(
"""
SELECT `o`.`OrderID`, `o`.`ProductID`, `o`.`Discount`, `o`.`Quantity`, `o`.`UnitPrice`
FROM `Order Details` AS `o`
WHERE (`o`.`OrderID` = 11077) AND (TAN(`o`.`Discount`) > 0)
""");
        }

        public override async Task Where_mathf_sign(bool async)
        {
            await base.Where_mathf_sign(async);

            AssertSql(
"""
SELECT `o`.`OrderID`, `o`.`ProductID`, `o`.`Discount`, `o`.`Quantity`, `o`.`UnitPrice`
FROM `Order Details` AS `o`
WHERE (`o`.`OrderID` = 11077) AND (SIGN(`o`.`Discount`) > 0)
""");
        }

        public override async Task Where_mathf_degrees(bool async)
        {
            await base.Where_mathf_degrees(async);

            AssertSql(
"""
SELECT `o`.`OrderID`, `o`.`ProductID`, `o`.`Discount`, `o`.`Quantity`, `o`.`UnitPrice`
FROM `Order Details` AS `o`
WHERE (`o`.`OrderID` = 11077) AND (DEGREES(`o`.`Discount`) > 0)
""");
        }

        public override async Task Where_mathf_radians(bool async)
        {
            await base.Where_mathf_radians(async);

            AssertSql(
"""
SELECT `o`.`OrderID`, `o`.`ProductID`, `o`.`Discount`, `o`.`Quantity`, `o`.`UnitPrice`
FROM `Order Details` AS `o`
WHERE (`o`.`OrderID` = 11077) AND (RADIANS(`o`.`Discount`) > 0)
""");
        }

        public override async Task Indexof_with_one_constant_arg(bool async)
        {
            await base.Indexof_with_one_constant_arg(async);

            AssertSql(
"""
SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE (LOCATE('a', `c`.`ContactName`) - 1) = 1
""");
        }

        public override async Task Indexof_with_one_parameter_arg(bool async)
        {
            await base.Indexof_with_one_parameter_arg(async);

            AssertSql(
"""
@__pattern_0='a' (Size = 4000)

SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE (LOCATE(@__pattern_0, `c`.`ContactName`) - 1) = 1
""");
        }

        public override async Task Indexof_with_constant_starting_position(bool async)
        {
            await base.Indexof_with_constant_starting_position(async);

            AssertSql(
"""
SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE (LOCATE('a', `c`.`ContactName`, 3) - 1) = 4
""");
        }

        public override async Task Indexof_with_parameter_starting_position(bool async)
        {
            await base.Indexof_with_parameter_starting_position(async);

            AssertSql(
"""
@__start_0='2'

SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE (LOCATE('a', `c`.`ContactName`, @__start_0 + 1) - 1) = 4
""");
        }

        public override async Task Replace_using_property_arguments(bool async)
        {
            await base.Replace_using_property_arguments(async);

            AssertSql(
"""
SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE REPLACE(`c`.`ContactName`, `c`.`ContactName`, `c`.`CustomerID`) = `c`.`CustomerID`
""");
        }

        public override async Task IsNullOrEmpty_negated_in_predicate(bool async)
        {
            await base.IsNullOrEmpty_negated_in_predicate(async);

            AssertSql(
"""
SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`Region` IS NOT NULL AND (`c`.`Region` <> '')
""");
        }

        public override async Task Where_DateOnly_FromDateTime(bool async)
        {
            await base.Where_DateOnly_FromDateTime(async);

            AssertSql(
"""
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE `o`.`OrderDate` IS NOT NULL AND (DATE(`o`.`OrderDate`) = DATE '1996-09-16')
""");
        }

        public override async Task String_StartsWith_with_StringComparison_Ordinal(bool async)
        {
            await base.String_StartsWith_with_StringComparison_Ordinal(async);

            AssertSql();
        }

        public override async Task String_StartsWith_with_StringComparison_OrdinalIgnoreCase(bool async)
        {
            await base.String_StartsWith_with_StringComparison_OrdinalIgnoreCase(async);

            AssertSql();
        }

        public override async Task String_EndsWith_with_StringComparison_Ordinal(bool async)
        {
            await base.String_EndsWith_with_StringComparison_Ordinal(async);

            AssertSql();
        }

        public override async Task String_EndsWith_with_StringComparison_OrdinalIgnoreCase(bool async)
        {
            await base.String_EndsWith_with_StringComparison_OrdinalIgnoreCase(async);

            AssertSql();
        }

        public override async Task String_Contains_with_StringComparison_Ordinal(bool async)
        {
            await base.String_Contains_with_StringComparison_Ordinal(async);

            AssertSql();
        }

        public override async Task String_Contains_with_StringComparison_OrdinalIgnoreCase(bool async)
        {
            await base.String_Contains_with_StringComparison_OrdinalIgnoreCase(async);

            AssertSql();
        }

        public override async Task String_StartsWith_with_StringComparison_unsupported(bool async)
        {
            await base.String_StartsWith_with_StringComparison_unsupported(async);

            AssertSql();
        }

        public override async Task String_EndsWith_with_StringComparison_unsupported(bool async)
        {
            await base.String_EndsWith_with_StringComparison_unsupported(async);

            AssertSql();
        }

        public override async Task String_Contains_in_projection(bool async)
        {
            await base.String_Contains_in_projection(async);

            AssertSql(
"""
SELECT `c`.`CustomerID` AS `Id`, `c`.`ContactName` IS NOT NULL AND ((LOCATE(`c`.`ContactName`, `c`.`CompanyName`) > 0) OR (`c`.`ContactName` LIKE '')) AS `Value`
FROM `Customers` AS `c`
""");
        }

        public override async Task String_Contains_negated_in_predicate(bool async)
        {
            await base.String_Contains_negated_in_predicate(async);

            AssertSql(
"""
SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE `c`.`ContactName` IS NULL OR ((LOCATE(`c`.`ContactName`, `c`.`CompanyName`) <= 0) AND `c`.`ContactName` NOT LIKE '')
""");
        }

        public override async Task String_Contains_negated_in_projection(bool async)
        {
            await base.String_Contains_negated_in_projection(async);

            AssertSql(
"""
SELECT `c`.`CustomerID` AS `Id`, `c`.`ContactName` IS NULL OR ((LOCATE(`c`.`ContactName`, `c`.`CompanyName`) <= 0) AND `c`.`ContactName` NOT LIKE '') AS `Value`
FROM `Customers` AS `c`
""");
        }

        public override async Task String_Contains_with_StringComparison_unsupported(bool async)
        {
            await base.String_Contains_with_StringComparison_unsupported(async);

            AssertSql();
        }

        public override async Task String_Join_non_aggregate(bool async)
        {
            await base.String_Join_non_aggregate(async);

            AssertSql(
"""
@__foo_0='foo' (Size = 4000)

SELECT `c`.`CustomerID`, `c`.`Address`, `c`.`City`, `c`.`CompanyName`, `c`.`ContactName`, `c`.`ContactTitle`, `c`.`Country`, `c`.`Fax`, `c`.`Phone`, `c`.`PostalCode`, `c`.`Region`
FROM `Customers` AS `c`
WHERE CONCAT_WS('|', `c`.`CompanyName`, @__foo_0, '', 'bar') = 'Around the Horn|foo||bar'
""");
        }

        public override async Task Where_math_max_nested(bool async)
        {
            await base.Where_math_max_nested(async);

            AssertSql(
"""
SELECT `o`.`OrderID`, `o`.`ProductID`, `o`.`Discount`, `o`.`Quantity`, `o`.`UnitPrice`
FROM `Order Details` AS `o`
WHERE (`o`.`OrderID` = 11077) AND (GREATEST(`o`.`OrderID`, `o`.`ProductID`, 1) = `o`.`OrderID`)
""");
        }

        public override async Task Where_math_max_nested_twice(bool async)
        {
            await base.Where_math_max_nested_twice(async);

            AssertSql(
"""
SELECT `o`.`OrderID`, `o`.`ProductID`, `o`.`Discount`, `o`.`Quantity`, `o`.`UnitPrice`
FROM `Order Details` AS `o`
WHERE (`o`.`OrderID` = 11077) AND (GREATEST(1, `o`.`OrderID`, 2, `o`.`ProductID`) = `o`.`OrderID`)
""");
        }

        public override async Task Where_math_min_nested(bool async)
        {
            await base.Where_math_min_nested(async);

            AssertSql(
"""
SELECT `o`.`OrderID`, `o`.`ProductID`, `o`.`Discount`, `o`.`Quantity`, `o`.`UnitPrice`
FROM `Order Details` AS `o`
WHERE (`o`.`OrderID` = 11077) AND (LEAST(`o`.`OrderID`, `o`.`ProductID`, 99999) = `o`.`ProductID`)
""");
        }

        public override async Task Where_math_min_nested_twice(bool async)
        {
            await base.Where_math_min_nested_twice(async);

            AssertSql(
"""
SELECT `o`.`OrderID`, `o`.`ProductID`, `o`.`Discount`, `o`.`Quantity`, `o`.`UnitPrice`
FROM `Order Details` AS `o`
WHERE (`o`.`OrderID` = 11077) AND (LEAST(99999, `o`.`OrderID`, 99998, `o`.`ProductID`) = `o`.`ProductID`)
""");
        }

        public override async Task Select_ToString_IndexOf(bool async)
        {
            await base.Select_ToString_IndexOf(async);

            AssertSql(
"""
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (LOCATE('123', CAST(`o`.`OrderID` AS char)) - 1) = -1
""");
        }

        public override async Task Select_IndexOf_ToString(bool async)
        {
            await base.Select_IndexOf_ToString(async);

            AssertSql(
"""
SELECT `o`.`OrderID`, `o`.`CustomerID`, `o`.`EmployeeID`, `o`.`OrderDate`
FROM `Orders` AS `o`
WHERE (LOCATE(CAST(`o`.`OrderID` AS char), '123') - 1) = -1
""");
        }

        public override Task Datetime_subtraction_TotalDays(bool async)
            => AssertTranslationFailed(() => base.Datetime_subtraction_TotalDays(async));

        [ConditionalFact]
        public virtual void Check_all_tests_overridden()
            => MySqlTestHelpers.AssertAllMethodsOverridden(GetType());

        private void AssertSql(params string[] expected)
            => Fixture.TestSqlLoggerFactory.AssertBaseline(expected);

        protected override void ClearLog()
            => Fixture.TestSqlLoggerFactory.Clear();
    }
}
