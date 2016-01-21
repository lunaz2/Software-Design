﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Writer;

namespace WriterTest
{
    [TestFixture]
    public class FIleWriterWithRemoveDuplicateOperatorTest : FileWriterTest
    {
        protected override void SetWriterOperators(BaseWriter writer)
        {
            writer.SetOperators(input => RemoveDuplicateOperator.Transform(input));
        }

        protected override string GetInput()
        {
            return "Remove Duplicate Test: something random random \n";
        }
    }
}
