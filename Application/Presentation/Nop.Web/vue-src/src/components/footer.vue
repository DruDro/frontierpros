<template>
    <footer class="footer">
        <v-container fluid v-if="$vuetify.breakpoint.smAndUp">
            <nav class="footer__nav">
                <div class="footer__nav-col">
                    <h4>Customer</h4>
                    <ul>
                        <li>
                            <a href="#">About Us</a>
                        </li>
                        <li>
                            <a href="#">Contact Us</a>
                        </li>
                        <li>
                            <a href="#">Blog</a>
                        </li>
                    </ul>
                </div>
                <div class="footer__nav-col">
                    <h4>Provider</h4>
                    <ul>
                        <li>
                            <a href="#">About Us</a>
                        </li>
                        <li>
                            <a href="#">Contact Us</a>
                        </li>
                        <li>
                            <a href="#">Blog</a>
                        </li>
                    </ul>
                </div>
                <div class="footer__nav-col">
                    <h4>Support</h4>
                    <ul>
                        <li>
                            <a href="#">About Us</a>
                        </li>
                        <li>
                            <a href="#">Contact Us</a>
                        </li>
                        <li>
                            <a href="#">Blog</a>
                        </li>
                    </ul>
                </div>
                <div class="footer__nav-col">
                    <h4>Company</h4>
                    <ul>
                        <li>
                            <a href="#">About Us</a>
                        </li>
                        <li>
                            <a href="#">Contact Us</a>
                        </li>
                        <li>
                            <a href="#">Blog</a>
                        </li>
                    </ul>
                </div>
                <div class="footer__nav-col">
                    <h4>Links</h4>
                    <ul class="social-links">
                        <li>
                            <a href="https://www.facebook.com/" target="_blank" class>
                                <i class="icon fab fa-facebook-f"></i>Facebook
                            </a>
                        </li>
                        <li>
                            <a href="https://twitter.com/" target="_blank" class>
                                <i class="icon fab fa-twitter"></i>Twitter
                            </a>
                        </li>
                        <li>
                            <a href="https://www.instagram.com/" target="_blank" class>
                                <i class="icon fab fa-instagram"></i>Instagram
                            </a>
                        </li>
                        <li>
                            <a href="https://www.linkedin.com/" target="_blank" class>
                                <i class="icon fab fa-linkedin-in"></i>LinkedIn
                            </a>
                        </li>
                    </ul>
                </div>
                <div class="footer__nav-col">
                    <h4>Download the app</h4>
                    <ul class="app-links">
                        <li>
                            <a href="#">
                                <svg-icon name="app_store_btn"></svg-icon>
                            </a>
                        </li>
                        <li>
                            <a href="#">
                                <svg-icon name="google_play_btn"></svg-icon>
                            </a>
                        </li>
                    </ul>
                </div>
            </nav>
        </v-container>
        <nav class="footer__nav" v-else>
            <v-list>
                <v-list-group append-icon>
                    <v-list-tile slot="activator">
                        <v-list-tile-title>
                            <span>Customer</span>
                        </v-list-tile-title>
                    </v-list-tile>
                    <v-list-tile>
                        <v-list-tile-title href="#">About Us</v-list-tile-title>
                    </v-list-tile>
                    <v-list-tile>
                        <v-list-tile-title href="#">Contact Us</v-list-tile-title>
                    </v-list-tile>
                    <v-list-tile>
                        <v-list-tile-title href="#">Blog</v-list-tile-title>
                    </v-list-tile>
                </v-list-group>
                <v-list-group append-icon>
                    <v-list-tile slot="activator">
                        <v-list-tile-title>
                            <span>Provider</span>
                        </v-list-tile-title>
                    </v-list-tile>
                    <v-list-tile>
                        <v-list-tile-title href="#">About Us</v-list-tile-title>
                    </v-list-tile>
                    <v-list-tile>
                        <v-list-tile-title href="#">Contact Us</v-list-tile-title>
                    </v-list-tile>
                    <v-list-tile>
                        <v-list-tile-title href="#">Blog</v-list-tile-title>
                    </v-list-tile>
                </v-list-group>
                <v-list-group append-icon>
                    <v-list-tile slot="activator">
                        <v-list-tile-title>
                            <span>Support</span>
                        </v-list-tile-title>
                    </v-list-tile>
                    <v-list-tile>
                        <v-list-tile-title href="#">About Us</v-list-tile-title>
                    </v-list-tile>
                    <v-list-tile>
                        <v-list-tile-title href="#">Contact Us</v-list-tile-title>
                    </v-list-tile>
                    <v-list-tile>
                        <v-list-tile-title href="#">Blog</v-list-tile-title>
                    </v-list-tile>
                </v-list-group>
                <v-list-group append-icon>
                    <v-list-tile slot="activator">
                        <v-list-tile-title>
                            <span>Company</span>
                        </v-list-tile-title>
                    </v-list-tile>
                    <v-list-tile>
                        <v-list-tile-title href="#">About Us</v-list-tile-title>
                    </v-list-tile>
                    <v-list-tile>
                        <v-list-tile-title href="#">Contact Us</v-list-tile-title>
                    </v-list-tile>
                    <v-list-tile>
                        <v-list-tile-title href="#">Blog</v-list-tile-title>
                    </v-list-tile>
                </v-list-group>
                <v-list-group append-icon>
                    <v-list-tile slot="activator">
                        <v-list-tile-title>
                            <span>Links</span>
                        </v-list-tile-title>
                    </v-list-tile>

                    <v-list-tile>
                        <v-list-tile-title href="https://www.facebook.com/" target="_blank">
                            <v-icon class="icon">fab fa-facebook-f</v-icon>Facebook
                        </v-list-tile-title>
                    </v-list-tile>
                    <v-list-tile>
                        <v-list-tile-title href="https://twitter.com/" target="_blank">
                            <v-icon class="icon">fab fa-twitter</v-icon>Twitter
                        </v-list-tile-title>
                    </v-list-tile>
                    <v-list-tile>
                        <v-list-tile-title href="https://www.instagram.com/" target="_blank">
                            <v-icon class="icon">fab fa-instagram</v-icon>Instagram
                        </v-list-tile-title>
                    </v-list-tile>
                    <v-list-tile>
                        <v-list-tile-title href="https://www.linkedin.com/" target="_blank">
                            <v-icon class="icon">fab fa-linkedin-in</v-icon>LinkedIn
                        </v-list-tile-title>
                    </v-list-tile>
                </v-list-group>
            </v-list>

            <ul class="app-links">
                <li>
                    <a href="#">
                        <svg-icon name="app_store_btn"></svg-icon>
                    </a>
                </li>
                <li>
                    <a href="#">
                        <svg-icon name="google_play_btn"></svg-icon>
                    </a>
                </li>
            </ul>
        </nav>
    </footer>
</template>
<style lang="scss">
.footer {
    padding: 10px 0 0;
    background: #fff;
    margin: 0;
    z-index: 4;
    box-shadow: 0 0 15px -5px rgba(0, 0, 0, 0.15);
    &__nav {
        display: flex;
        flex-flow: row wrap;
        align-items: flex-start;
        justify-content: space-between;
        padding: 0;
        &-col {
            flex: 1 1 calc(16.6% - 40px);
            flex-basis: calc(16.6% - 40px);
            margin: 0 20px 20px;
            &:first-child {
                margin-left: 0;
            }
            &:last-child {
                margin-right: 0;
            }
        }
        @include b(tablet) {
            &-col {
                flex: 1 0 calc(33.33% - 40px);
                flex-basis: calc(33.33% - 40px);
                &:first-child {
                    margin-left: 20px;
                }
                &:last-child {
                    margin-right: 20px;
                }
            }
        }
        @include b(mobile) {
            &-col {
                flex: 1 0 calc(50% - 40px);
                flex-basis: calc(50% - 40px);
            }
        }
        @include b(599) {
            display: block;
            text-align: center;
        }
        .v-list__tile {
            padding: 0;
            height: 36px;
            color: #7094f7;
            &__title {
                text-align: center !important;
                font-weight: 500;
                .icon {
                    font-size: 18px;
                    display: inline-block;
                    vertical-align: text-bottom;
                    margin-right: 10px;
                    color: #7094f7;
                }
            }
        }
        [role="listitem"] {
            flex: 0 1 auto !important;
            padding: 0 15px;
            text-align: center;
        }
        .v-list__group__header {
            display: flex;
            align-items: center;
            justify-content: center;
            padding: 0 15px;
            [role="listitem"] {
                padding: 0;
                overflow: visible !important;
            }
            .v-list__tile__title {
                overflow: visible !important;
                span {
                    margin-right: 10px;
                    line-height: 1em;
                    vertical-align: middle;
                    display: inline-block;
                }
                &:after {
                    content: "";
                    border: 1px solid $themeColor;
                    border-width: 0 1px 1px 0;
                    transform: rotate(45deg);
                    display: inline-block;
                    width: 10px;
                    height: 10px;
                    vertical-align: middle;
                    font-size: 0;
                    line-height: 0;
                    top: -3px;
                    position: relative;
                    transition: all 0.15s ease-in-out;
                }
            }

            &--active {
                .v-list__tile__title {
                    &:after {
                        transform: rotate(-135deg);
                        top: 3px;
                    }
                }
            }
        }
    }
    ul {
        text-align: left;
        margin: 0;
        padding: 0;
        li {
            padding: 0 0 10px;
            margin: 0;
            line-height: 0;
            @include b(min) {
                text-align: center;
            }
            &:before {
                display: none;
            }
            a {
                color: $mainFontColor;
                font-size: 16px;
                font-weight: 300;
                line-height: 1em;
                &:hover {
                    text-decoration: underline;
                    color: #000;
                }
            }
        }
    }
    h4 {
        font-size: 18px;
        line-height: 1em;
        padding: 0 0 15px;
        font-weight: 500;
        margin: 0;
        color: $themeColor;
    }
    .social-links {
        a {
            display: inline-flex;
            align-items: flex-end;
            line-height: 1em;
            .icon {
                margin-right: 10px;
                font-size: 1em;
                width: 16px;
                color: $mainFontColor;
            }
        }
    }
    .app-links {
        li {
            font-size: 0;
            line-height: 0;
            &:last-child {
                padding-top: 10px;
            }
        }
        a {
            display: inline-block;
            border-radius: 50px;
            font-size: 0;
            img,
            svg {
                display: block;
                $height: 44px;
                height: $height;
                width: $height * 3.66;
                max-width: 100%;
                border-radius: 50px;
                fill: #7094f7;
                transition: fill 0.15s ease-in-out;
            }
            &:hover,
            &:focus {
                svg {
                    fill: #171a77;
                }
            }
        }
        @include b(599) {
            text-align: center;
            display: flex;
            align-items: center;
            justify-content: center;
            padding: 20px 0 30px;
            li {
                flex: 0 1 160px;
                padding: 0 15px !important;
                a {
                    display: block;
                    width: 100%;
                    img,
                    svg {
                        width: 100%;
                        height: auto;
                        max-height: 44px;
                    }
                }
            }
        }
    }
}
</style>
