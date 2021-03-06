﻿// [[[[INFO>
// Copyright 2015 Epicycle (http://epicycle.org, https://github.com/open-epicycle)
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// 
// For more information check https://github.com/open-epicycle/Epicycle.Photogrammetry-cs
// ]]]]

using Epicycle.Math.Geometry;

namespace Epicycle.Photogrammetry
{
    public interface IImageModel
    {
        Vector3 OpticalCenter { get; }

        Box2 Domain { get; }

        // might return null when spacePoint is outside of visible region
        // when spacePoint is outside of visible region but result is not null, it is guaranteed to be outside of Domain 
        Vector2? Project(Vector3 spacePoint);

        // applies differential of projection
        // might return null when spacePoint is outside of visible region
        // when spacePoint is outside of visible region but result is not null, it is guaranteed to be outside of Domain
        Vector2? ProjectTangent(Vector3 spacePoint, Vector3 tangent);

        // might return null when imagePoint is outside of visible region
        Vector3 LineOfSight(Vector2 imagePoint);

        // interesects segment with visible region
        // returns null when segment is outside of visible region
        Segment3? CropVisible(Segment3 segment);
        
        // interesects segment with visible region, projects the result and returns the endpoints of the resulting curve
        // returns null when segment is outside of visible region
        Segment2? Project(Segment3 segment);               
    }
}
