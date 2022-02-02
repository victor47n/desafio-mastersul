import { GetServerSideProps } from 'next';
import Head from "next/head";
import Link from 'next/link';
import { api } from '../services/api';

import styles from './home.module.scss';

type Payment = {
  id: string;
  type: string;
  value: number;
}

type Grid = {
  type: string;
  payments: Payment[];
}

type User = {
  id: string;
  name: string;
  grids: Grid[];
}

type HomeProps = {
  users: User[];
}

export default function Home({ users }: HomeProps) {

  return (
    <div className={styles.homepage}>
      <Head>
        <title>Inicio | Desafio Mastersul</title>
      </Head>

      <section className={styles.latestEpisodes}>
        <h2>Últimos lançamentos</h2>

        <ul>
          {users.map((user, index) => {
            return (
              <li key={user.id}>
                <div className={styles.episodeDetails}>
                  <p>{user.name}</p>
                  <div className={styles.grids}>
                    {user.grids.map((grid, index) => {
                      return <span key={index}>{grid.type}</span>
                    })}
                  </div>
                </div>

                <button type="button">
                  <Link href={`/user/${user.id}`}>
                    <img src="/eye.svg" alt="Visualizar grids" />
                  </Link>
                </button>
              </li>
            )
          })}
        </ul>
      </section>
    </div>
  )
}

// As informações são executadas no lado do servido e não do navegador,
// tendo assim as informações já pré-renderizadas pelo Next.js
export const getServerSideProps: GetServerSideProps = async () => {
  const { data } = await api.get('/users');

  const users = data.map(user => {
    return {
      id: user.id,
      name: user.name,
      grids: user.grids
    };
  })

  return {
    props: {
      users
    },
  }
}