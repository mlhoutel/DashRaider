﻿Shader "Custom/SpriteShadowEmissive" {
	Properties{
		_Color("Color", Color) = (1,1,1,1)
		[PerRendererData]_MainTex("Sprite Texture", 2D) = "white" {}
		_Cutoff("Shadow alpha cutoff", Range(0,1)) = 0.5
		_EmissionLM("Emission (Lightmapper)", Float) = 0
		[Toggle] _DynamicEmissionLM("Dynamic Emission (Lightmapper)", Int) = 0
	}
		SubShader{
			Tags
			{
				"Queue" = "Geometry"
				"RenderType" = "TransparentCutout"
			}
			LOD 200

			Cull Off

			CGPROGRAM
				// Lambert lighting model, and enable shadows on all light types
				#pragma surface surf Lambert addshadow fullforwardshadows

				// Use shader model 3.0 target, to get nicer looking lighting
				#pragma target 3.0

				sampler2D _MainTex;
				fixed4 _Color;
				fixed _Cutoff;
				fixed _EmissionLM;

				struct Input
				{
					float2 uv_MainTex;
					float f_EmissionLM;
				};

				void surf(Input IN, inout SurfaceOutput o) {
					fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
					o.Albedo = c.rgb;
					o.Alpha = c.a;
					clip(o.Alpha - _Cutoff);
					o.Emission = c.rgb * _EmissionLM;
				}
			ENDCG
			}
		FallBack "Diffuse"
}