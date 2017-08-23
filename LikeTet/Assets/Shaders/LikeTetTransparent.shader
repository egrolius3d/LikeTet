Shader "Custom/LikeTetTransparent" {
//Diffuse + Specular + Transparent
	Properties{
		_Color ("Color",Color) = (1,1,1,1)
		_MainTex ("Texture",2D)= "white" {}
		_Alpha ("Alpha",Range(0,1))=0.6
		_NormalIntensity ("Normal intensity", Range (0,3))=1
		[NoScaleOffset] _NormalMap ("Normal map", 2D)= "gray"{}
		_SpecularColor ("Specular Color",Color)= (1,1,1,1)
		_SpecShininess ("Specular Shininess", Range(1.0,100.0))= 2.0
		}

	SubShader{
		Tags { "RenderType"="Transparent" "Queue" = "Transparent" }
		LOD 200
		Blend SrcAlpha OneMinusSrcAlpha
		Lighting On
		Pass{
		CGPROGRAM
			#pragma vertex VertexProgram
			#pragma fragment FragmentProgram
			float4 _Color;
			sampler2D _MainTex;
			sampler2D _NormalMap;
			float4 _MainTex_ST;
			half _Alpha;
			float _NormalIntensity;
			float4 _SpecularColor;
			float _SpecShininess;

			#include "UnityCG.cginc"
			#include "UnityStandardBRDF.cginc"

		//Interpolator
			struct Interpolator{
				float4 position:SV_POSITION;
				float2 uv:TEXCOORD0;
				float3 normal:TEXCOORD1;
				float3 worldPos:TEXCOORD2;

			};
		//VertexData
			struct VertexData{
				float4 position:POSITION;
				float2 uv:TEXCOORD0;
				float3 normal:TEXCOORD1;
			};
		//Vertex Interpolator 
			Interpolator VertexProgram (VertexData v){
				Interpolator i;
				i.position= UnityObjectToClipPos(v.position);
				i.worldPos= mul(unity_ObjectToWorld,v.position);
				i.normal=UnityObjectToWorldNormal(v.normal);
				i.uv=v.uv* _MainTex_ST.xy+ _MainTex_ST.zw;
				return i;
			}

		//Fragment Interpolator
			float4 FragmentProgram(Interpolator c):SV_TARGET{
				float4 output= tex2D(_MainTex,c.uv)*_Color;
				//Light color
					float3 lightColor= _LightColor0.rgb;
				//direction of light
					float3 lightDir=_WorldSpaceLightPos0.xyz;
				//direction of camera
					float3 viewDir= normalize (_WorldSpaceCameraPos-c.worldPos);
				//normal calculation
				//calculate normal from texture for each fragment
					c.normal= _NormalIntensity*UnpackNormal (tex2D (_NormalMap,c.uv));
				//diffuse calculation
					float3 diffuse= lightColor*_Color*max(0.0,dot(c.normal,lightDir));
				//specular calculation
					float3 specular;
					if (dot(c.normal,lightDir)<0.0)
					{
						specular = float3(0.0,0.0,0.0);
					}
					else
					{
						specular = lightColor*_SpecularColor.rgb*pow(max(0.0,dot(reflect(-lightDir,c.normal),viewDir)), _SpecShininess);
					}

				output.a=_Color.a;
				//mixing diffuse with specular and main texture
					output.rgb= output.rgb+diffuse+specular;
					return output;
			}

		ENDCG
		}
	}
}
