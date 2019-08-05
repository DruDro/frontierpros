module.exports = {
    publicPath: '/app/',
    outputDir: '../wwwroot/app',
    filenameHashing: false,
    css: {
        loaderOptions: {
            sass: {
                data: `
				@import "~@/style/main.scss";
			`
            }
        }
    },

    pluginOptions: {
        svgSprite: {
            dir: 'src/assets/icons',
            test: /\.(svg)(\?.*)?$/,
            loaderOptions: {
                extract: true,
                spriteFilename: 'img/icons.[hash:8].svg'
            },
            pluginOptions: {
                plainSprite: true
            }
        }
    },
    chainWebpack: config => {
        config.module
            .rule('svg-sprite')
            .use('svgo-loader')
            .loader('svgo-loader');
    }
};