﻿using System;

/// <summary>
/// Copyright 2010 Neuroph Project http://neuroph.sourceforge.net
/// 
/// Licensed under the Apache License, Version 2.0 (the "License");
/// you may not use this file except in compliance with the License.
/// You may obtain a copy of the License at
/// 
///    http://www.apache.org/licenses/LICENSE-2.0
/// 
/// Unless required by applicable law or agreed to in writing, software
/// distributed under the License is distributed on an "AS IS" BASIS,
/// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
/// See the License for the specific language governing permissions and
/// limitations under the License.
/// </summary>

namespace org.neuroph.core.learning.stop {


    /// <summary>
    /// Stops learning rule if specified number of iterations has been reached
    /// @author Zoran Sevarac <sevarac@gmail.com>
    /// </summary>
    [Serializable]
    public class MaxIterationsStop : StopCondition {

        private IterativeLearning learningRule;

        public MaxIterationsStop(IterativeLearning learningRule) {
            this.learningRule = learningRule;
        }

        public virtual bool Reached {
            get {


                if (learningRule.CurrentIteration >= learningRule.MaxIterations) {
                    return true;
                }

                return false;
            }
        }


    }
}