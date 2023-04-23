using System;
using ConsoleApplication1.Departments.Builders.Impl;
using ConsoleApplication1.Departments.Impl;
using ConsoleApplication1.Testing;
using ConsoleApplication1.Workers.Constants;
using ConsoleApplication1.Workers.Impl;

namespace ConsoleApplication1
{
    internal class Program
    {
        private static CSharpTestingModule TestingModule = new CSharpTestingModule();

        private static void FisherTests()
        {
            TestingModule.StartTest("Fisher");
            var fisher1 = new Fisher("MrBeast", 250, 0, FishingSpecialty.FISHING);
            var fisher2 = new Fisher("MrBeast", 250, 0, FishingSpecialty.LOADING);
            var fisher3 = new Fisher("MrBeast", 250, 0, FishingSpecialty.CAPTAIN);

            Console.WriteLine(TestingModule.AssertEqual(fisher1.Work(2), 504));
            Console.WriteLine(TestingModule.AssertEqual(fisher2.Work(2), 506));
            Console.WriteLine(TestingModule.AssertEqual(fisher3.Work(2), 508));
            TestingModule.EndTest();
        }

        private static void BusinessAnalyticTests()
        {
            TestingModule.StartTest("Business Analytics");
            var ba1 = new BusinessAnalyst("IShowSpeed", 300, 0, BusinessTeam.INCOME);
            var ba2 = new BusinessAnalyst("IShowSpeed", 300, 0, BusinessTeam.TAXING);

            Console.WriteLine(TestingModule.AssertEqual(ba1.Work(4), 1216));
            Console.WriteLine(TestingModule.AssertEqual(ba2.Work(4), 1208));
            Console.WriteLine(TestingModule.AssertEqual(ba2.Work(4), 1210)); // Wrong
            TestingModule.EndTest();
        }

        private static void FishingDepartmentTests()
        {
            TestingModule.StartTest("Fisher Department");
            var fisher1 = new Fisher("MrBeast", 250, 0, FishingSpecialty.FISHING);
            var fisher2 = new Fisher("MrBeast", 250, 0, FishingSpecialty.LOADING);
            var fisher3 = new Fisher("MrBeast", 250, 0, FishingSpecialty.CAPTAIN);

            var fishingDepartment = new FishingDepartment();

            fishingDepartment.Hire(fisher1);
            fishingDepartment.Hire(fisher2);
            fishingDepartment.Hire(fisher3);

            Console.WriteLine(TestingModule.AssertEqual(fishingDepartment.Length(), 3));

            Console.WriteLine(TestingModule.AssertEqual(fishingDepartment.GetWorker(0), fisher1));
            Console.WriteLine(TestingModule.AssertEqual(fishingDepartment.GetWorker(1), fisher2));
            Console.WriteLine(TestingModule.AssertEqual(fishingDepartment.GetWorker(2), fisher3));
            Console.WriteLine(TestingModule.AssertEqual(fishingDepartment.GetWorker(2), fisher2)); // Wrong

            fishingDepartment.Fire(fisher1);
            Console.WriteLine(TestingModule.AssertEqual(fishingDepartment.Length(), 2));

            fishingDepartment.Fire(fisher1);
            Console.WriteLine(TestingModule.AssertEqual(fishingDepartment.Length(), 2));
            Console.WriteLine(TestingModule.AssertEqual(fishingDepartment.Length(),
                1)); // Wrong cos we tried to remove an element which was previously removed

            fishingDepartment.Fire(fisher2);
            fishingDepartment.Fire(fisher3);
            Console.WriteLine(TestingModule.AssertEqual(fishingDepartment.Length(), 0));

            /*
             * Sometimes department will have enough money to fix a boat, and sometimes not. Try this test multiple times to see failure and success of the method
             */
            try
            {
                fishingDepartment.FixBoat();
            }
            catch (Exception e)
            {
                TestingModule.DebugPrint(e.Message);
            }

            // Negative budget means debt
            Console.WriteLine(TestingModule.AssertGreater(fishingDepartment.Budget, 0));

            TestingModule.EndTest();
        }

        private static void BusinessDepartmentTests()
        {
            TestingModule.StartTest("Business Department");
            var ba1 = new BusinessAnalyst("John", 250, 0, BusinessTeam.INCOME);
            var ba2 = new BusinessAnalyst("John", 250, 0, BusinessTeam.TAXING);

            var baDepartment = new BusinessDepartment();

            baDepartment.Hire(ba1);
            baDepartment.Hire(ba2);

            Console.WriteLine(TestingModule.AssertEqual(baDepartment.GetWorker(0), ba1));
            Console.WriteLine(TestingModule.AssertEqual(baDepartment.GetWorker(1), ba2));

            baDepartment.Fire(ba1);
            Console.WriteLine(TestingModule.AssertEqual(baDepartment.Length(), 1));

            baDepartment.Fire(ba1);
            Console.WriteLine(TestingModule.AssertEqual(baDepartment.Length(), 1));
            Console.WriteLine(TestingModule.AssertEqual(baDepartment.Length(),
                0)); // Wrong cos we tried to remove an element which was previously removed

            baDepartment.Fire(ba2);
            Console.WriteLine(TestingModule.AssertEqual(baDepartment.Length(), 0));

            /*
             * Sometimes department will have enough money to pay tax, and sometimes not. Try this test multiple times to see failure and success of the method
             */
            try
            {
                baDepartment.PayTaxes();
            }
            catch (Exception e)
            {
                TestingModule.DebugPrint(e.Message);
            }

            try
            {
                baDepartment.PayTaxes();
            }
            catch (Exception e)
            {
                TestingModule.DebugPrint(e.Message);
            }

            try
            {
                baDepartment.PayTaxes();
            }
            catch (Exception e)
            {
                TestingModule.DebugPrint(e.Message);
            }

            try
            {
                baDepartment.PayTaxes();
            }
            catch (Exception e)
            {
                TestingModule.DebugPrint(e.Message);
            }

            // Negative budget means debt
            Console.WriteLine(TestingModule.AssertGreater(baDepartment.Budget, 0));

            TestingModule.EndTest();
        }

        private static void FishingDepartmentBuilderTests()
        {
            TestingModule.StartTest("Fisher Department Builder");
            
            var fisher1 = new Fisher("MrBeast", 250, 0, FishingSpecialty.FISHING);
            var fisher2 = new Fisher("MrBeast", 250, 0, FishingSpecialty.LOADING);
            var fisher3 = new Fisher("MrBeast", 250, 0, FishingSpecialty.CAPTAIN);
            
            var fishDepBuilder = new FishingDepartmentBuilder();
            var fishingDepartment = fishDepBuilder.Builder().addWorker(fisher1).addWorker(fisher2).addWorker(fisher3).Build();
            
            Console.WriteLine(TestingModule.AssertEqual(fishingDepartment.GetWorker(0), fisher1));
            Console.WriteLine(TestingModule.AssertEqual(fishingDepartment.GetWorker(1), fisher2));
            Console.WriteLine(TestingModule.AssertEqual(fishingDepartment.GetWorker(2), fisher3));
            Console.WriteLine(TestingModule.AssertEqual(fishingDepartment.GetWorker(1), fisher3)); // Wrong
            
            TestingModule.DebugPrint(fishingDepartment);
            
            TestingModule.EndTest();
        }
        
        private static void BusinessDepartmentBuilderTests()
        {
            TestingModule.StartTest("Business Department Builder");
            
            var ba1 = new BusinessAnalyst("John", 250, 0, BusinessTeam.INCOME);
            var ba2 = new BusinessAnalyst("John", 250, 0, BusinessTeam.TAXING);
            
            var businessDepBuilder = new BusinessDepartmentBuilder();
            var businessDepartment = businessDepBuilder.Builder().addWorker(ba1).addWorker(ba2).Build();
            
            Console.WriteLine(TestingModule.AssertEqual(businessDepartment.GetWorker(0), ba1));
            Console.WriteLine(TestingModule.AssertEqual(businessDepartment.GetWorker(1), ba2));
            Console.WriteLine(TestingModule.AssertEqual(businessDepartment.GetWorker(0), ba2)); // Wrong
            
            TestingModule.DebugPrint(businessDepartment);
            
            TestingModule.EndTest();
        }

        public static void Main(string[] args)
        {
            // Comment tests you don't want to see

            FisherTests();
            BusinessAnalyticTests();
            FishingDepartmentTests();
            BusinessDepartmentTests();
            FishingDepartmentBuilderTests();
            BusinessDepartmentBuilderTests();
            Console.WriteLine(TestingModule.ShowResult());
        }
    }
}