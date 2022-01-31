import { useState } from 'react'
import { AppProps } from 'next/app'
import { Header } from '../components/Header'
import Modal from 'react-modal'

import { PaymentModal } from '../components/PaymentModal'

import '../styles/global.scss'
import styles from '../styles/app.module.scss'

function MyApp({ Component, pageProps }: AppProps) {
  return (
    <>
      <div className={styles.wrapper}>
        <main>
          <Header />
          <Component {...pageProps} />          
        </main>
      </div>
    </>
  )
}

export default MyApp
