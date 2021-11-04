Shader "Custom/Pulse"
{
    Properties
    {
        [HDR]
        _Color("Color", Color) = (1,1,1,1)
        _TimeScale("Time Scale", Range(0.0, 2)) = 2
        _Frequency("Frequency", Range(1, 20)) = 5
        _Threshold("Treshold", Range(0.1, 1)) = 0.2
        _Radius("Radius", Range(0, 0.3)) = 0.2
        _MainTex("Albedo (RGB)", 2D) = "white" {}

    }
        SubShader
    {
        Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Lambert alpha:fade

        sampler2D _MainTex;
        float _TimeScale;
        float _Frequency;
        float _Threshold;
        float4 _Color;
        float _Radius;

        struct Input
        {
            float2 uv_MainTex;
        };



        void surf(Input IN, inout SurfaceOutput o)
        {
            // Define the x and y position in the fragment, also define the center of the circle

            float posX = IN.uv_MainTex.x;
            float posY = IN.uv_MainTex.y;
            float2 center = (0.5, 0.5);
            // calculate the euclidian distance of the point from the center.
            float dist = sqrt(pow(posX - center.x, 2) + pow(posY - center.y, 2));
            //calculate the value as a function of time.

            float value = frac((dist - _Time.y * _TimeScale) * _Frequency);
            o.Albedo = dist < _Radius ? 0 : (value < _Threshold ? smoothstep(0.0, _Threshold - 0.1, value) * _Color : 0);
            o.Alpha = dist < _Radius ? 0 : (value < _Threshold ? smoothstep(0.0, _Threshold - 0.1, value) : 0);

            //Make the corner of the quad always invisible
            o.Alpha = dist > 0.5 ? 0 : o.Alpha;
        }
        ENDCG
    }
        FallBack "Diffuse"
}


