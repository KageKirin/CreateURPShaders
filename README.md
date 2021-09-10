# CreateNewURPShaders

This packages is a small editor extension for Unity (2021.1+, but we could backport to older versions as well),
that adds 2 new menu entries:

- _Assets -> Create -> Shader -> Universal Render Pipeline -> New Lit Shader_
    to create a new shader based on _URP/Lit_, i.e. a plain copy of its source
- _Assets -> Create -> Shader -> Universal Render Pipeline -> New Empty Shader_
    to create a new shader for URP that contains merely the skeleton of a shader

## Details

### Lit shader

This functionality retrieves the original _URL/Lit_ shader, and copies its source
into the new shader as destination. The shader name gets adapted along the way.

### Empty shader

The skeleton of the _empty_ shader is based on Unity's sample given in the
[URP documentation](https://docs.unity3d.com/Packages/com.unity.render-pipelines.universal@11.0/manual/writing-shaders-urp-basic-unlit-structure.html).

## Rationale for this package

I was tired of having to do this by hand every time I wanted to create a customized shader.
