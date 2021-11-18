#version 330 core

in vec2 texture_coords;

out vec4 FragColor;

uniform sampler2D ourTex;
uniform float time;
uniform float amount = 0.05f;
uniform float density = 10.0f;
uniform float speed = 1.0f;

vec4 effect(sampler2D sample, vec2 texture_coords, vec3 color) {
	float offset_y = amount * sin(time * speed + texture_coords.x * density);
	//if (mod(gl_FragCoord.x, 4.) > 1) offset_y *= -1.;

	float offset_x = amount * sin(time * speed + texture_coords.y * density);
	//if (mod(gl_FragCoord.x, 4.) > 1) offset_x *= -1.;

	texture_coords.x += offset_x;
	texture_coords.y += offset_y;
	texture_coords.x = mod(texture_coords.x, 1.);
    texture_coords.y = mod(texture_coords.y, 1.);
	return vec4(color, 1.0f) *texture(sample, texture_coords);
}

void main() {
	FragColor = effect(ourTex, texture_coords, vec3(sin(time), cos(time), 1.0f));
}