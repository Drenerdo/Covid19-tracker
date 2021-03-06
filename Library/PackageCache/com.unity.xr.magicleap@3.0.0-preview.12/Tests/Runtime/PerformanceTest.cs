using System;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Unity.XR.MagicLeap.Tests
{
    public class PerformanceTest : TestBaseSetup
    {
        int m_NonPerformantFrameCount;
#pragma warning disable 0414
        private int m_CubeCount = 0;

        bool m_TestingFocalPoint = false;
#pragma warning restore 0414
        // we have observed a drop in performance between simulation and runtime
        // on the device - in the editor, we've seen it fluctuate from 54-60 FPS
        // when the device runs just fine (also giving a little bit of elbow room
        // for when simulation tanks the frame rate a bit more than what we've seen)
        const float k_FrameTimeMax = 1f / 52f;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            m_TestingFocalPoint = false;
            m_CubeCount = 0;
        }

        public void Update()
        {
            if (Time.deltaTime > k_FrameTimeMax)
                ++m_NonPerformantFrameCount;
        }

        [UnityTest]
        [RequireMagicLeapDevice]
        public IEnumerator SimpleHoloFpsTest()
        {
            m_TestSetupHelpers.TestCubeSetup(TestCubesConfig.TestCube);
            yield return new WaitForSeconds(4f);

            Assert.AreEqual(0, m_NonPerformantFrameCount,
                "Failed to keep every frame inside the target frame time for the tested window");
        }

        [UnityTest]
        [RequireMagicLeapDevice]
        public IEnumerator SimpleHoloFpsTestWithFocalPoint()
        {
            m_TestingFocalPoint = true;
            m_TestSetupHelpers.TestCubeSetup(TestCubesConfig.TestCube);
            yield return new WaitForSeconds(4f);

            Assert.AreEqual(0, m_NonPerformantFrameCount,
                "Failed to keep every frame inside the target frame time for the tested window");
        }

        [UnityTest]
        [RequireMagicLeapDevice]
        public IEnumerator MassObjectsFpsTest()
        {
            m_TestSetupHelpers.TestCubeSetup(TestCubesConfig.PerformanceMassObjects);

            yield return new WaitForSeconds(4f);

            Assert.AreEqual(0, m_NonPerformantFrameCount,
                "Failed to keep every frame inside the target frame time for the tested window");
        }

        [UnityTest]
        [RequireMagicLeapDevice]
        public IEnumerator MassFloorObjectsFpsTest()
        {
            m_TestSetupHelpers.TestCubeSetup(TestCubesConfig.PerformanceMassFloorObjects);

            yield return new WaitForSeconds(4f);

            Assert.AreEqual(0, m_NonPerformantFrameCount,
                "Failed to keep every frame inside the target frame time for the tested window");
        }
    }
}
