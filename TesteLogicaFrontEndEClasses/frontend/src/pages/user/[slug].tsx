import { useEffect, useState } from 'react';
import Head from 'next/head';
import { useRouter } from 'next/router'

import { api } from '../../services/api';

import styles from './user.module.scss';
import { PaymentModal } from '../../components/PaymentModal';
import Modal from 'react-modal';
import Link from 'next/link';

// Setando o elemento root aonde o Modal deve ser construido
Modal.setAppElement('#root');

type Payment = {
    id: number;
    type: string;
    value: number;
}

type Grid = {
    type: string;
    payments: Payment[];
}

export default function User() {
    const router = useRouter();
    const { slug } = router.query;

    const [isPaymentModalOpen, setIsPaymentModalOpen] = useState(false);
    const [payment, setPayment] = useState<Payment>({} as Payment);

    const [grids, setGrids] = useState<Grid[]>([])

    // Será chamado na primeira vez que é executada a página
    // e toda vez que a constant slug ser modificada
    useEffect(() => {
        if (!slug) {
            return;
        }

        const fetchPaymentByUserId = async () => {
            await api.get(`payments/${slug}`)
                .then(response => setGrids(response.data))
        }

        fetchPaymentByUserId()
    }, [slug])

    // Recebe um pagamento e abre o modal
    function handleOpenPaymentModal(payment: Payment) {
        setPayment({
            id: payment.id,
            type: payment.type,
            value: payment.value
        });

        setIsPaymentModalOpen(true);
    }

    // Fecha o modal
    function handleClosePaymentModal() {
        setIsPaymentModalOpen(false);
    }

    // Responsável por remover um pagamento de um grid
    // especifico
    function removePayment(id: number) {
        try {
            const updatedGrids = [...grids];
            // Busca o index do grid que conter o id do pagamento
            const gridIndex = updatedGrids.findIndex(grid => grid.payments.find(payment => payment.id === id));

            // Se obtiver um index ele utilizara o mesmo
            // para que possa remover corretamente o pagamento
            // que foi passado por parâmetro
            if (gridIndex >= 0) {
                updatedGrids[gridIndex].payments.splice(
                    updatedGrids[gridIndex].payments.findIndex(payment => payment.id === id),
                    1)

                setGrids(updatedGrids);
                handleClosePaymentModal();
            } else {
                throw Error();
            }
        } catch {
            alert('Erro na remoção da conta');
        }
    }

    return (
        <div className={styles.container}>
            <Head>
                <title>Teste | Desafio Mastersul</title>
            </Head>

            <button type="button" className={styles.backButton}>
                <Link href={`/`}>
                    <img src="/arrow_left.svg" alt="Voltar" />
                </Link>
            </button>

            <div className={styles.grid}>
                {grids.map(grid => (
                    <div key={grid.type}>
                        <table cellSpacing={0}>
                            <thead>
                                <tr>
                                    <th>Tipo</th>
                                    <th>Valor</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>
                                {grid.payments.map(payment => (
                                    <tr key={payment.id}>
                                        <td>{payment.type}</td>
                                        <td>
                                            {new Intl.NumberFormat('pt-BR', {
                                                style: 'currency',
                                                currency: 'BRL'
                                            }).format(payment.value)}
                                        </td>
                                        <td>
                                            <button type="button" onClick={() => handleOpenPaymentModal(payment)}>
                                                <img src="/eye.svg" alt="Visualizar detalhes" />
                                            </button>
                                        </td>
                                    </tr>
                                ))}
                            </tbody>
                        </table>
                    </div>
                ))}
            </div>

            <PaymentModal
                isOpen={isPaymentModalOpen}
                onRequestClose={handleClosePaymentModal}
                payment={payment}
                onRemovePayment={removePayment}
            />
        </div>
    )
}