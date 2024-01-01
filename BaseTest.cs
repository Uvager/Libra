using System.Drawing;
using System.Threading.Tasks;
using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[assembly:Parallelizable(ParallelScope.All)]
[assembly:LevelOfParallelism(4)]

namespace PlaywrightTests;

[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class BaseTest : PageTest
{
    [OneTimeSetUp]
    public static void OneTimeSetUp()
    {
        

    }

    [OneTimeTearDown]
    public static void OneTimeTearDown() 
    {
    }

    [SetUp]
    public async Task SetUp()
    {
        await Task.Delay(0);
        BasePage page = new BasePage(Page);
        await page.GoUrl();
    }

    [TearDown]
    public async Task TearDown()
    {
        await Task.Delay(0);
    }

}