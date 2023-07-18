using System.Numerics;
using System.Runtime.InteropServices;
using System.Security;

namespace Raylib_cs
{
    [SuppressUnmanagedCodeSecurity]
    public static unsafe partial class Rlgl
    {
        /// <summary>
        /// Used by DllImport to load the native library
        /// </summary>
        public const string NativeLibName = "raylib";

        public const int DEFAULT_BATCH_BUFFER_ELEMENTS = 8192;
        public const int DEFAULT_BATCH_BUFFERS = 1;
        public const int DEFAULT_BATCH_DRAWCALLS = 256;
        public const int MAX_BATCH_ACTIVE_TEXTURES = 4;
        public const int MAX_MATRIX_STACK_SIZE = 32;
        public const float RL_CULL_DISTANCE_NEAR = 0.01f;
        public const float RL_CULL_DISTANCE_FAR = 1000.0f;

        // Texture parameters (equivalent to OpenGL defines)
        public const int RL_TEXTURE_WRAP_S = 0x2802;
        public const int RL_TEXTURE_WRAP_T = 0x2803;
        public const int RL_TEXTURE_MAG_FILTER = 0x2800;
        public const int RL_TEXTURE_MIN_FILTER = 0x2801;

        public const int RL_TEXTURE_FILTER_NEAREST = 0x2600;
        public const int RL_TEXTURE_FILTER_LINEAR = 0x2601;
        public const int RL_TEXTURE_FILTER_MIP_NEAREST = 0x2700;
        public const int RL_TEXTURE_FILTER_NEAREST_MIP_LINEAR = 0x2702;
        public const int RL_TEXTURE_FILTER_LINEAR_MIP_NEAREST = 0x2701;
        public const int RL_TEXTURE_FILTER_MIP_LINEAR = 0x2703;
        public const int RL_TEXTURE_FILTER_ANISOTROPIC = 0x3000;
        public const int RL_TEXTURE_MIPMAP_BIAS_RATIO = 0x4000;

        public const int RL_TEXTURE_WRAP_REPEAT = 0x2901;
        public const int RL_TEXTURE_WRAP_CLAMP = 0x812F;
        public const int RL_TEXTURE_WRAP_MIRROR_REPEAT = 0x8370;
        public const int RL_TEXTURE_WRAP_MIRROR_CLAMP = 0x8742;

        // GL equivalent data types
        public const int RL_UNSIGNED_BYTE = 0x1401;
        public const int RL_FLOAT = 0x1406;

        // Buffer usage hint
        public const int RL_STREAM_DRAW = 0x88E0;
        public const int RL_STREAM_READ = 0x88E1;
        public const int RL_STREAM_COPY = 0x88E2;
        public const int RL_STATIC_DRAW = 0x88E4;
        public const int RL_STATIC_READ = 0x88E5;
        public const int RL_STATIC_COPY = 0x88E6;
        public const int RL_DYNAMIC_DRAW = 0x88E8;
        public const int RL_DYNAMIC_READ = 0x88E9;
        public const int RL_DYNAMIC_COPY = 0x88EA;

        // GL blending factors
        public const int RL_ZERO = 0;
        public const int RL_ONE = 1;
        public const int RL_SRC_COLOR = 0x0300;
        public const int RL_ONE_MINUS_SRC_COLOR = 0x0301;
        public const int RL_SRC_ALPHA = 0x0302;
        public const int RL_ONE_MINUS_SRC_ALPHA = 0x0303;
        public const int RL_DST_ALPHA = 0x0304;
        public const int RL_ONE_MINUS_DST_ALPHA = 0x0305;
        public const int RL_DST_COLOR = 0x0306;
        public const int RL_ONE_MINUS_DST_COLOR = 0x0307;
        public const int RL_SRC_ALPHA_SATURATE = 0x0308;
        public const int RL_CONSTANT_COLOR = 0x8001;
        public const int RL_ONE_MINUS_CONSTANT_COLOR = 0x8002;
        public const int RL_CONSTANT_ALPHA = 0x8003;
        public const int RL_ONE_MINUS_CONSTANT_ALPHA = 0x8004;

        // GL blending functions/equations
        public const int RL_FUNC_ADD = 0x8006;
        public const int RL_MIN = 0x8007;
        public const int RL_MAX = 0x8008;
        public const int RL_FUNC_SUBTRACT = 0x800A;
        public const int RL_FUNC_REVERSE_SUBTRACT = 0x800B;
        public const int RL_BLEND_EQUATION = 0x8009;
        public const int RL_BLEND_EQUATION_RGB = 0x8009;
        public const int RL_BLEND_EQUATION_ALPHA = 0x883D;
        public const int RL_BLEND_DST_RGB = 0x80C8;
        public const int RL_BLEND_SRC_RGB = 0x80C9;
        public const int RL_BLEND_DST_ALPHA = 0x80CA;
        public const int RL_BLEND_SRC_ALPHA = 0x80CB;
        public const int RL_BLEND_COLOR = 0x8005;

        // ------------------------------------------------------------------------------------
        // Functions Declaration - Matrix operations
        // ------------------------------------------------------------------------------------

        /// <summary>Choose the current matrix to be transformed</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlMatrixMode(int mode);

        /// <inheritdoc cref="rlMatrixMode(int)"/>
        public static void rlMatrixMode(MatrixMode mode)
        {
            rlMatrixMode((int)mode);
        }

        /// <summary>Push the current matrix to stack</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlPushMatrix();

        /// <summary>Pop lattest inserted matrix from stack</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlPopMatrix();

        /// <summary>Reset current matrix to identity matrix</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlLoadIdentity();

        /// <summary>Multiply the current matrix by a translation matrix</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlTranslatef(float x, float y, float z);

        /// <summary>Multiply the current matrix by a rotation matrix</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlRotatef(float angle, float x, float y, float z);

        /// <summary>Multiply the current matrix by a scaling matrix</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlScalef(float x, float y, float z);

        /// <summary>
        /// Multiply the current matrix by another matrix<br/>
        /// Current Matrix can be set via <see cref="rlMatrixMode(int)"/>
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlMultMatrixf(float* matf);

        /// <inheritdoc cref="rlMultMatrixf(float*)"/>
        public static void rlMultMatrixf(Matrix4x4 matf)
        {
            Float16 f = Raymath.MatrixToFloatV(matf);
            rlMultMatrixf(f.v);
        }

        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlFrustum(
            double left,
            double right,
            double bottom,
            double top,
            double znear,
            double zfar
        );

        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlOrtho(
            double left,
            double right,
            double bottom,
            double top,
            double znear,
            double zfar
        );

        /// <summary>Set the viewport area</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlViewport(int x, int y, int width, int height);


        // ------------------------------------------------------------------------------------
        // Functions Declaration - Vertex level operations
        // ------------------------------------------------------------------------------------

        /// <summary>Initialize drawing mode (how to organize vertex)</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlBegin(int mode);

        public static void rlBegin(DrawMode mode)
        {
            rlBegin((int)mode);
        }

        /// <summary>Finish vertex providing</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlEnd();

        /// <summary>Define one vertex (position) - 2 int</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlVertex2i(int x, int y);

        /// <summary>Define one vertex (position) - 2 float</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlVertex2f(float x, float y);

        /// <summary>Define one vertex (position) - 3 float</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlVertex3f(float x, float y, float z);

        /// <summary>Define one vertex (texture coordinate) - 2 float</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlTexCoord2f(float x, float y);

        /// <summary>Define one vertex (normal) - 3 float</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlNormal3f(float x, float y, float z);

        /// <summary>Define one vertex (color) - 4 byte</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlColor4ub(byte r, byte g, byte b, byte a);

        /// <summary>Define one vertex (color) - 3 float</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlColor3f(float x, float y, float z);

        /// <summary>Define one vertex (color) - 4 float</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlColor4f(float x, float y, float z, float w);


        // ------------------------------------------------------------------------------------
        // Functions Declaration - OpenGL equivalent functions (common to 1.1, 3.3+, ES2)
        // NOTE: This functions are used to completely abstract raylib code from OpenGL layer
        // ------------------------------------------------------------------------------------

        /// <summary>Vertex buffers state</summary>

        /// <summary>Enable vertex array (VAO, if supported)</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool rlEnableVertexArray(uint vaoId);

        /// <summary>Disable vertex array (VAO, if supported)</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDisableVertexArray();

        /// <summary>Enable vertex buffer (VBO)</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlEnableVertexBuffer(uint id);

        /// <summary>Disable vertex buffer (VBO)</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDisableVertexBuffer();

        /// <summary>Enable vertex buffer element (VBO element)</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlEnableVertexBufferElement(uint id);

        /// <summary>Disable vertex buffer element (VBO element)</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDisableVertexBufferElement();

        /// <summary>Enable vertex attribute index</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlEnableVertexAttribute(uint index);

        /// <summary>Disable vertex attribute index</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDisableVertexAttribute(uint index);

        /// <summary>Enable attribute state pointer<br/>
        /// NOTE: Only available for GRAPHICS_API_OPENGL_11</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlEnableStatePointer(int vertexAttribType, void* buffer);

        /// <summary>Disable attribute state pointer<br/>
        /// NOTE: Only available for GRAPHICS_API_OPENGL_11</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDisableStatePointer(int vertexAttribType);


        // Textures state

        /// <summary>Select and active a texture slot</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlActiveTextureSlot(int slot);

        /// <summary>Enable texture</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlEnableTexture(uint id);

        /// <summary>Disable texture</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDisableTexture();

        /// <summary>Enable texture cubemap</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlEnableTextureCubemap(uint id);

        /// <summary>Disable texture cubemap</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDisableTextureCubemap();

        /// <summary>Set texture parameters (filter, wrap)</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlTextureParameters(uint id, int param, int value);

        /// <summary>Set cubemap parameters (filter, wrap)</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlCubemapParameters(uint id, int param, int value);


        // Shader state

        /// <summary>Enable shader program</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlEnableShader(uint id);

        /// <summary>Disable shader program</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDisableShader();


        // Framebuffer state

        /// <summary>Enable render texture (fbo)</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlEnableFramebuffer(uint id);

        /// <summary>Disable render texture (fbo), return to default framebuffer</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDisableFramebuffer();

        /// <summary>Activate multiple draw color buffers</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlActiveDrawBuffers(int count);


        // General render state

        /// <summary>Enable color blending</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlEnableColorBlend();

        /// <summary>Disable color blending</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDisableColorBlend();

        /// <summary>Enable depth test</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlEnableDepthTest();

        /// <summary>Disable depth test</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDisableDepthTest();

        /// <summary>Enable depth write</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlEnableDepthMask();

        /// <summary>Disable depth write</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDisableDepthMask();

        /// <summary>Enable backface culling</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlEnableBackfaceCulling();

        /// <summary>Disable backface culling</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDisableBackfaceCulling();

        /// <summary>Set face culling mode</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlSetCullFace(int mode);

        /// <summary>Enable scissor test</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlEnableScissorTest();

        /// <summary>Disable scissor test</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDisableScissorTest();

        /// <summary>Scissor test</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlScissor(int x, int y, int width, int height);

        /// <summary>Enable wire mode</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlEnableWireMode();

        /// <summary>Disable wire mode</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDisableWireMode();

        /// <summary>Set the line drawing width</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlSetLineWidth(float width);

        /// <summary>Get the line drawing width</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float rlGetLineWidth();

        /// <summary>Enable line aliasing</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlEnableSmoothLines();

        /// <summary>Disable line aliasing</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDisableSmoothLines();

        /// <summary>Enable stereo rendering</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlEnableStereoRender();

        /// <summary>Disable stereo rendering</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDisableStereoRender();

        /// <summary>Check if stereo render is enabled</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool rlIsStereoRenderEnabled();

        /// <summary>Clear color buffer with color</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlClearColor(byte r, byte g, byte b, byte a);

        /// <summary>Clear used screen buffers (color and depth)</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlClearScreenBuffers();

        /// <summary>Check and log OpenGL error codes</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlCheckErrors();

        /// <summary>Set blending mode</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlSetBlendMode(BlendMode mode);

        /// <summary>Set blending mode factor and equation (using OpenGL factors)</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlSetBlendFactors(int glSrcFactor, int glDstFactor, int glEquation);

        /// <summary>Set blending mode factors and equations separately (using OpenGL factors)</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlSetBlendFactorsSeparate(
            int glSrcRGB,
            int glDstRGB,
            int glSrcAlpha,
            int glDstAlpha,
            int glEqRGB,
            int glEqAlpha
        );


        // ------------------------------------------------------------------------------------
        // Functions Declaration - rlgl functionality
        // ------------------------------------------------------------------------------------

        /// <summary>Initialize rlgl (buffers, shaders, textures, states)</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlglInit(int width, int height);

        /// <summary>De-inititialize rlgl (buffers, shaders, textures)</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlglClose();

        /// <summary>Load OpenGL extensions</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlLoadExtensions(void* loader);

        /// <summary>Get current OpenGL version</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern GlVersion rlGetVersion();

        /// <summary>Get default framebuffer width</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rlGetFramebufferWidth();

        /// <summary>Get default framebuffer height</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rlGetFramebufferHeight();

        /// <summary>Get default texture</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint rlGetTextureIdDefault();

        /// <summary>Get default shader</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint rlGetShaderIdDefault();

        /// <summary>Get default shader locations</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int* rlGetShaderLocsDefault();

        // Render batch management

        /// <summary>Load a render batch system<br/>
        /// NOTE: rlgl provides a default render batch to behave like OpenGL 1.1 immediate mode<br/>
        /// but this render batch API is exposed in case custom batches are required</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern RenderBatch rlLoadRenderBatch(int numBuffers, int bufferElements);

        /// <summary>Unload render batch system</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlUnloadRenderBatch(RenderBatch batch);

        /// <summary>Draw render batch data (Update->Draw->Reset)</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDrawRenderBatch(RenderBatch* batch);

        /// <summary>Set the active render batch for rlgl (NULL for default internal)</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlSetRenderBatchActive(RenderBatch* batch);

        /// <summary>Update and draw internal render batch</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDrawRenderBatchActive();

        /// <summary>Check internal buffer overflow for a given number of vertex</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool rlCheckRenderBatchLimit(int vCount);

        /// <summary>Set current texture for render batch and check buffers limits</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlSetTexture(uint id);


        // Vertex buffers management

        /// <summary>Load vertex array (vao) if supported</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint rlLoadVertexArray();

        /// <summary>Load a vertex buffer attribute</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint rlLoadVertexBuffer(void* buffer, int size, CBool dynamic);

        /// <summary>Load a new attributes element buffer</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint rlLoadVertexBufferElement(void* buffer, int size, CBool dynamic);

        /// <summary>Update GPU buffer with new data</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlUpdateVertexBuffer(uint bufferId, void* data, int dataSize, int offset);

        /// <summary>Update vertex buffer elements with new data</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlUpdateVertexBufferElements(uint id, void* data, int dataSize, int offset);

        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlUnloadVertexArray(uint vaoId);

        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlUnloadVertexBuffer(uint vboId);

        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlSetVertexAttribute(
            uint index,
            int compSize,
            int type,
            CBool normalized,
            int stride,
            void* pointer
        );

        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlSetVertexAttributeDivisor(uint index, int divisor);

        /// <summary>Set vertex attribute default value</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlSetVertexAttributeDefault(int locIndex, void* value, int attribType, int count);

        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDrawVertexArray(int offset, int count);

        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDrawVertexArrayElements(int offset, int count, void* buffer);

        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDrawVertexArrayInstanced(int offset, int count, int instances);

        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlDrawVertexArrayElementsInstanced(
            int offset,
            int count,
            void* buffer,
            int instances
        );


        // Textures data management

        /// <summary>Load texture in GPU</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint rlLoadTexture(void* data, int width, int height, PixelFormat format, int mipmapCount);

        /// <summary>Load depth texture/renderbuffer (to be attached to fbo)</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint rlLoadTextureDepth(int width, int height, CBool useRenderBuffer);

        /// <summary>Load texture cubemap</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint rlLoadTextureCubemap(void* data, int size, PixelFormat format);

        /// <summary>Update GPU texture with new data</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlUpdateTexture(
            uint id,
            int offsetX,
            int offsetY,
            int width,
            int height,
            PixelFormat format,
            void* data
        );

        /// <summary>Get OpenGL internal formats</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlGetGlTextureFormats(
            PixelFormat format,
            int* glInternalFormat,
            int* glFormat,
            int* glType
        );

        /// <summary>Get OpenGL internal formats</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern sbyte* rlGetPixelFormatName(PixelFormat format);

        /// <summary>Unload texture from GPU memory</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlUnloadTexture(uint id);

        /// <summary>Generate mipmap data for selected texture</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlGenTextureMipmaps(uint id, int width, int height, PixelFormat format, int* mipmaps);

        /// <summary>Read texture pixel data</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void* rlReadTexturePixels(uint id, int width, int height, PixelFormat format);

        /// <summary>Read screen pixel data (color buffer)</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte* rlReadScreenPixels(int width, int height);


        // Framebuffer management (fbo)

        /// <summary>Load an empty framebuffer</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint rlLoadFramebuffer(int width, int height);

        /// <summary>Attach texture/renderbuffer to a framebuffer</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlFramebufferAttach(
            uint fboId,
            uint texId,
            FramebufferAttachType attachType,
            FramebufferAttachTextureType texType,
            int mipLevel
        );

        /// <summary>Verify framebuffer is complete</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CBool rlFramebufferComplete(uint id);

        /// <summary>Delete framebuffer from GPU</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlUnloadFramebuffer(uint id);


        // Shaders management

        /// <summary>Load shader from code strings</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint rlLoadShaderCode(sbyte* vsCode, sbyte* fsCode);

        /// <summary>Compile custom shader and return shader id<br/>
        /// (type: RL_VERTEX_SHADER, RL_FRAGMENT_SHADER, RL_COMPUTE_SHADER)</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint rlCompileShader(sbyte* shaderCode, int type);

        /// <summary>Load custom shader program</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint rlLoadShaderProgram(uint vShaderId, uint fShaderId);

        /// <summary>Unload shader program</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlUnloadShaderProgram(uint id);

        /// <summary>Get shader location uniform</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rlGetLocationUniform(uint shaderId, sbyte* uniformName);

        /// <summary>Get shader location attribute</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int rlGetLocationAttrib(uint shaderId, sbyte* attribName);

        /// <summary>Set shader value uniform</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlSetUniform(int locIndex, void* value, int uniformType, int count);

        /// <summary>Set shader value matrix</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlSetUniformMatrix(int locIndex, Matrix4x4 mat);

        /// <summary>Set shader value sampler</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlSetUniformSampler(int locIndex, uint textureId);

        /// <summary>Set shader currently active (id and locations)</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlSetShader(uint id, int* locs);


        // Compute shader management

        /// <summary>Load compute shader program</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint rlLoadComputeShaderProgram(uint shaderId);

        /// <summary>Dispatch compute shader (equivalent to *draw* for graphics pilepine)</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlComputeShaderDispatch(uint groupX, uint groupY, uint groupZ);


        // Shader buffer storage object management (ssbo)

        /// <summary>Load shader storage buffer object (SSBO)</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint rlLoadShaderBuffer(uint size, void* data, int usageHint);

        /// <summary>Unload shader storage buffer object (SSBO)</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlUnloadShaderBuffer(uint ssboId);

        /// <summary>Update SSBO buffer data</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlUpdateShaderBuffer(uint id, void* data, uint dataSize, uint offset);

        /// <summary>Bind SSBO buffer data</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlBindShaderBuffer(uint id, uint index);

        /// <summary>Read SSBO buffer data (GPU->CPU)</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlReadShaderBuffer(uint id, void* dest, uint count, uint offset);

        /// <summary>Copy SSBO data between buffers</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlCopyShaderBuffer(
            uint destId,
            uint srcId,
            uint destOffset,
            uint srcOffset,
            uint count
        );

        /// <summary>Get SSBO buffer size</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint rlGetShaderBufferSize(uint id);


        // Buffer management

        /// <summary>Bind image texture</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlBindImageTexture(uint id, uint index, int format, CBool readOnly);


        // Matrix state management

        /// <summary>Get internal modelview matrix</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Matrix4x4 rlGetMatrixModelview();

        /// <summary>Get internal projection matrix</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Matrix4x4 rlGetMatrixProjection();

        /// <summary>Get internal accumulated transform matrix</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Matrix4x4 rlGetMatrixTransform();

        /// <summary>Get internal projection matrix for stereo render (selected eye)</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Matrix4x4 rlGetMatrixProjectionStereo(int eye);

        /// <summary>Get internal view offset matrix for stereo render (selected eye)</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Matrix4x4 rlGetMatrixViewOffsetStereo(int eye);

        /// <summary>Set a custom projection matrix (replaces internal projection matrix)</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlSetMatrixProjection(Matrix4x4 view);

        /// <summary>Set a custom modelview matrix (replaces internal modelview matrix)</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlSetMatrixModelview(Matrix4x4 proj);

        /// <summary>Set eyes projection matrices for stereo rendering</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlSetMatrixProjectionStereo(Matrix4x4 left, Matrix4x4 right);

        /// <summary>Set eyes view offsets matrices for stereo rendering</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlSetMatrixViewOffsetStereo(Matrix4x4 left, Matrix4x4 right);


        // Quick and dirty cube/quad buffers load->draw->unload

        /// <summary>Load and draw a cube</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlLoadDrawCube();

        /// <summary>Load and draw a quad</summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rlLoadDrawQuad();
    }
}

